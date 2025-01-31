
using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.Analisis.ObtenerPorId;
using LAFT.Abstracciones.Modelos.Analisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using LAFT.AccesoADatos.ModuloAnalisis.ObtenerPorIdAnalisisPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ModuloAnalisis.ObtenerPorId
{
    public class ObtenerPorIdAnalisisPersonaLN : IObtenerPorIdAnalisisPersonaLN
    {
        IObtenerPorIdAnalisisPersonaAD  _listarPorIdAD;
        public ObtenerPorIdAnalisisPersonaLN()
        {
            _listarPorIdAD = new ObtenerPorIdAnalisisPersonaAD();
        }

        public List<AnalisisDTO> Detalle(int idPersona)
        {

            List<AnalisisDTO> laListaDeAnalisis = _listarPorIdAD.Detalle(idPersona);
            return laListaDeAnalisis;
        }


        private List<AnalisisDTO> ObtenerLaListaConvertida(List<AnalisisTabla> laListaDeAnalisis)
        {
            List<AnalisisDTO> laListaDeAnalisises = new List<AnalisisDTO>();
            foreach (AnalisisTabla elAnalisis in laListaDeAnalisis)
            {
                laListaDeAnalisises.Add(ConvertirObjetoAnalisisDto(elAnalisis));
            }
            return laListaDeAnalisises;
        }
        private AnalisisDTO ConvertirObjetoAnalisisDto(AnalisisTabla elAnalisis)
        {
            return new AnalisisDTO
            {
                FechaDeAnalisis = elAnalisis.FechaDeAnalisis.ToString("dd-MM-yyyy hh:mm tt"),
                Comentario = elAnalisis.Comentario,
                IdAnalisis = elAnalisis.IdAnalisis,
                IdPersona = elAnalisis.IdPersona,
                NivelDeRiesgoGenerado = elAnalisis.NivelDeRiesgoGenerado,
                TotalDePalabrasClaveEncontradas = elAnalisis.TotalDePalabrasClaveEncontradas,
                CantidadDeArchivosEmparejados = elAnalisis.CantidadDeArchivosEmparejados,
            };
        }
    }
}
