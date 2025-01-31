using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.Analisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using LAFT.AccesoADatos.Analisis.Registrar;
using LAFT.LN.Analisis.Registrar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ModuloAnalisis.Registrar
{
    public class RegistrarAnalisisLN : IRegistrarAnalisisLN
    {
        IRegistrarAnalisisAD _registrarAnalisisAD;
        IAnalisisLN _analizarPersonaLN;
        IFecha _fecha;
        IRegistrarBitacoraEventosLN _registrarBitacora;

        public RegistrarAnalisisLN()
        {
            _fecha = new Fecha();
            _analizarPersonaLN = new AnalizarLN();
            _registrarAnalisisAD = new RegistrarAnalisisAD();
            _registrarBitacora = new RegistrarBitacoraEventosLN();
        }

        public void Registrar(int idPersona)
        {
            var (nivelDeRiesgo, cantidadPalabrasClave, cantidadArchivos) = _analizarPersonaLN.Analizar(idPersona);

            int nivelDeRiesgoGenerado = ConvertirNivelDeRiesgo(nivelDeRiesgo);

            var analisis = new AnalisisTabla
            {
                IdPersona = idPersona,
                NivelDeRiesgoGenerado = nivelDeRiesgoGenerado,
                TotalDePalabrasClaveEncontradas = cantidadPalabrasClave,
                CantidadDeArchivosEmparejados = cantidadArchivos,
                FechaDeAnalisis = _fecha.ObtenerFecha(),
                Comentario = GenerarComentario(nivelDeRiesgoGenerado)
            };

            // Save the analysis to the database
            int result = _registrarAnalisisAD.Guardar(analisis).Result;
            if (result > 0)
            {
                // Handle successful save (maybe log or notify the user)
            }
            else
            {
                // Handle failure (maybe log or notify the user)
            }
        }

        private int ConvertirNivelDeRiesgo(string nivelDeRiesgo)
        {
            if (nivelDeRiesgo == "Sin análisis") return 0;
            if (nivelDeRiesgo == "Riesgo bajo") return 1;
            if (nivelDeRiesgo == "Riesgo medio") return 2;
            if (nivelDeRiesgo == "Riesgo alto") return 3;
            if (nivelDeRiesgo == "Riesgo crítico") return 4;
            return 0;
        }

        private string GenerarComentario(int nivelDeRiesgo)
        {
            if (nivelDeRiesgo == 0) return "No se encontraron suficientes datos para el análisis.";
            if (nivelDeRiesgo == 1) return "Nivel de riesgo bajo basado en los datos analizados.";
            if (nivelDeRiesgo == 2) return "Riesgo moderado, revisar los datos detallados.";
            if (nivelDeRiesgo == 3) return "Riesgo elevado, se recomienda mayor atención.";
            if (nivelDeRiesgo == 4) return "Riesgo crítico, acción inmediata requerida.";
            return "Análisis realizado.";
        }



    }
}

