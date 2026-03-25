using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Listar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.Registrar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.Listar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Listar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.ObtenerPorID;
using LAFT.Abstracciones.LN.Interfaces.Analisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Conversion;
using LAFT.Abstracciones.Modelos.ActividadesPersona;
using LAFT.Abstracciones.Modelos.Analisis;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.ActividadesPersona.Listar;
using LAFT.AccesoADatos.Analisis.Registrar;
using LAFT.AccesoADatos.ArchivosAnalisis.Listar;
using LAFT.AccesoADatos.PalabrasClave.Listar;
using LAFT.AccesoADatos.Persona.ObtenerPorId;
using LAFT.LN.General;
using LAFT.LN.General.Conversiones.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.Analisis.Registrar
{
    public class AnalizarLN : IAnalisisLN
    {
        IObtenerPersonaPorIdAD _obtenerPorIdAD;
        IListarPalabraClaveAD _listarPalabraClaveAD;
        IConvertirPalabrasClaveDTOAPalabrasClaveTablaLN _convertirAPalabrasClaveDto;
        IListarActividadesPersonaAD _listarActividadesAD;
        IListarArchivosAnalisisAD _listarArchivoAnalisisAD;

        public AnalizarLN()
        {
            _obtenerPorIdAD = new ObtenerPersonaPorIdAD();
            _listarPalabraClaveAD = new ListarPalabraClaveAD();
            _convertirAPalabrasClaveDto = new ConvertirPalabrasClaveDTOAPalabrasClaveTablaLN();
            _listarActividadesAD = new ListarActividadesPersonaAD();
            _listarArchivoAnalisisAD = new ListarArchivosAnalisisAD();


        }


        public (string NivelRiesgoGenerado, int TotalDePalabrasClaveEncontradas, int CantidadArchivosEmparejado) Analizar(int idPersona)
        {
            List<PalabrasClaveDTO> palabrasClaveLista = ListarPalabras() ?? new List<PalabrasClaveDTO>();

            PersonaDTO persona = Obtener(idPersona);
            if (persona == null)
            {
                return ("Sin análisis", 0, 0);
            }

            List<ArchivosAnalisisDTO> archivos = ObtenerArchivos(persona);

            int contadorPalabras = 0;

            // Lista de palabras para convertirlas en string para el foreach
            List<string> palabrasClave = palabrasClaveLista
                .Where(p => p != null && !string.IsNullOrEmpty(p.Palabra))
                .Select(p => p.Palabra)
                .ToList();

            foreach (var archivo in archivos)
            {
                if (archivo == null)
                {
                    continue;
                }

                string contenidoArchivo = archivo.TextoDelArchivo ?? string.Empty;
                if (contenidoArchivo.Length == 0)
                {
                    continue;
                }
                List<string> palabrasEncontradas = new List<string>();

                foreach (var palabra in palabrasClave)
                {
                    if (contenidoArchivo.IndexOf(palabra, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (!palabrasEncontradas.Contains(palabra))
                        {
                            palabrasEncontradas.Add(palabra);
                            contadorPalabras++;
                        }
                    }
                }
            }

            List<ActividadesPersonaDTO> actividades = ListarActividades(idPersona) ?? new List<ActividadesPersonaDTO>();

            int cantidadArchivos = archivos.Count;
            int cantidadPalabrasClave = contadorPalabras;
            int actividadesBajas = actividades.Count(a => a.NivelDeRiesgo == 1);
            int actividadesMedias = actividades.Count(a => a.NivelDeRiesgo == 2);
            int actividadesAltas = actividades.Count(a => a.NivelDeRiesgo == 3);

            string nivelRiesgo = "";

            if (actividadesBajas >= 1 && actividadesBajas <= 5 && cantidadArchivos >= 1 && cantidadPalabrasClave == 0)
            {
                nivelRiesgo = "Riesgo bajo";
            }
            else if ((actividadesBajas > 5 || actividadesMedias >= 1) && cantidadArchivos > 4 && cantidadPalabrasClave >= 1 && cantidadPalabrasClave <= 5)
            {
                nivelRiesgo = "Riesgo medio";
            }
            else if ((actividadesMedias > 4 || actividadesAltas >= 1) && cantidadArchivos >= 5 && cantidadArchivos <= 9 && cantidadPalabrasClave >= 5 && cantidadPalabrasClave <= 10)
            {
                nivelRiesgo = "Riesgo alto";
            }
            else if (actividadesAltas > 1 && cantidadArchivos > 10 && cantidadPalabrasClave > 10)
            {
                nivelRiesgo = "Riesgo crítico";
            }

            if (string.IsNullOrEmpty(nivelRiesgo))
            {
                nivelRiesgo = "Sin análisis";
            }

            return (nivelRiesgo, cantidadPalabrasClave, cantidadArchivos);
        }

        private List<ArchivosAnalisisDTO> FiltrarArchivosPorPersonaFisica(List<ArchivosAnalisisDTO> listaDeArchivos, PersonaDTO persona)
        {
            return listaDeArchivos.Where(archivo =>
            {
                string texto = archivo?.TextoDelArchivo ?? string.Empty;
                if (texto.Length == 0)
                {
                    return false;
                }

                return (!string.IsNullOrEmpty(persona.NombrePersona) && texto.IndexOf(persona.NombrePersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(persona.PrimerApellidoPersona) && texto.IndexOf(persona.PrimerApellidoPersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(persona.SegundoApellidoPersona) && texto.IndexOf(persona.SegundoApellidoPersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(persona.IdentificacionPersona) && texto.IndexOf(persona.IdentificacionPersona, StringComparison.OrdinalIgnoreCase) >= 0);
            }).ToList();
        }


        private List<ArchivosAnalisisDTO> FiltrarArchivosPorPersonaJuridica(List<ArchivosAnalisisDTO> listaDeArchivos, PersonaDTO persona)
        {
            return listaDeArchivos.Where(archivo =>
            {
                string texto = archivo?.TextoDelArchivo ?? string.Empty;
                if (texto.Length == 0)
                {
                    return false;
                }

                return (!string.IsNullOrEmpty(persona.NombrePersona) && texto.IndexOf(persona.NombrePersona, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(persona.IdentificacionPersona) && texto.IndexOf(persona.IdentificacionPersona, StringComparison.OrdinalIgnoreCase) >= 0);
            }).ToList();
        }

        private List<ArchivosAnalisisDTO> ObtenerArchivos(PersonaDTO persona)
        {
            if (persona == null)
            {
                return new List<ArchivosAnalisisDTO>();
            }

            List<ArchivosAnalisisDTO> listaDeArchivos = _listarArchivoAnalisisAD.Listar() ?? new List<ArchivosAnalisisDTO>();

            if (persona.TipoIdentificacion == 1)
            {
                return FiltrarArchivosPorPersonaFisica(listaDeArchivos, persona);
            }
            else if (persona.TipoIdentificacion == 2)
            {
                return FiltrarArchivosPorPersonaJuridica(listaDeArchivos, persona);
            }

            return new List<ArchivosAnalisisDTO>();
        }

        private List<ActividadesPersonaDTO> ListarActividades(int idPersona)
        {
            List<ActividadesPersonaDTO> laListaDeActividades = _listarActividadesAD.ListarActividadesPersona(idPersona);
            return laListaDeActividades;
        }




        private PersonaDTO Obtener(int IdPersona)
        {
            PersonaTabla laPersonaEnBD = _obtenerPorIdAD.Obtener(IdPersona);
            if (laPersonaEnBD == null)
            {
                return null;
            }

            return ConvertirAPersonaAMostrar(laPersonaEnBD);
        }


        private List<PalabrasClaveDTO> ListarPalabras()
        {
            List<PalabrasClaveDTO> laListaDePalabras = _listarPalabraClaveAD.Listar();
            return laListaDePalabras;
        }
        private PersonaDTO ConvertirAPersonaAMostrar(PersonaTabla laPersonaEnBD)
        {
            return new PersonaDTO
            {
                IdPersona = laPersonaEnBD.IdPersona,
                IdentificacionPersona = laPersonaEnBD.IdentificacionPersona,
                TipoIdentificacion = laPersonaEnBD.TipoIdentificacion,
                NombrePersona = laPersonaEnBD.NombrePersona,
                PrimerApellidoPersona = laPersonaEnBD.PrimerApellidoPersona,
                SegundoApellidoPersona = laPersonaEnBD.SegundoApellidoPersona,
                Estado = laPersonaEnBD.Estado
            };
        }

    }
}
