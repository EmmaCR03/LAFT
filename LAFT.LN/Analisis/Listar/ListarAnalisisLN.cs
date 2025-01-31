using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.Listar;
using LAFT.Abstracciones.LN.Interfaces.Analisis.Listar;
using LAFT.Abstracciones.Modelos.Analisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.Analisis.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.Analisis.Listar
{
    public class ListarAnalisisLN : IListarAnalisisLN
    {
        IListarAnalisisAD _listarAnalisisAD;

        public ListarAnalisisLN()
        {
            _listarAnalisisAD = new ListarAnalisisAD();
        }

        public List<PersonaAnalizadaDto> Listar()
        {
            List<PersonaAnalizadaDto> laListasDeArchivos = _listarAnalisisAD.Listar();

            return laListasDeArchivos;
        }

        private List<PersonaAnalizadaDto> ObtenerLaListaConvertida(List<AnalisisTabla> listaDeAnalisis, List<PersonaTabla> listaDePersonas)
        {
            List<PersonaAnalizadaDto> listaConvertida = new List<PersonaAnalizadaDto>();

            var joinLista = from elAnalisis in listaDeAnalisis
                            join laPersona in listaDePersonas on elAnalisis.IdPersona equals laPersona.IdPersona
                            select new { elAnalisis, laPersona };

            foreach (var item in joinLista)
            {
                listaConvertida.Add(ConvertirObjetoPersonaConAnalisisDto(item.elAnalisis, item.laPersona));
            }

            return listaConvertida;
        }

        private PersonaAnalizadaDto ConvertirObjetoPersonaConAnalisisDto(AnalisisTabla elAnalisis, PersonaTabla laPersona)
        {
            return new PersonaAnalizadaDto
            {
                TipoIdentificacion = laPersona.TipoIdentificacion,
                NombrePersona = laPersona.NombrePersona,
                PrimerApellidoPersona = laPersona.PrimerApellidoPersona,
                SegundoApellidoPersona = laPersona.SegundoApellidoPersona,
                NivelDeRiesgoGenerado = elAnalisis.NivelDeRiesgoGenerado,
                FechaDeAnalisis = elAnalisis.FechaDeAnalisis
            };
        }

    }
}

