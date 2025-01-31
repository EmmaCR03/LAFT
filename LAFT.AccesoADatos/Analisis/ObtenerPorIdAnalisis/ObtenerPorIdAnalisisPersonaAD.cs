using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.ObtenerPorId;
using LAFT.Abstracciones.Modelos.Analisis;
using LAFT.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBancoNacional.AccesoADatos.ModuloAnalisis.ObtenerPorIdAnalisisPersona
{
    public class ObtenerPorIdAnalisisPersonaAD : IObtenerPorIdAnalisisPersonaAD
    {
        Contexto _elContexto;

        public ObtenerPorIdAnalisisPersonaAD()
        {
            _elContexto = new Contexto();
        }
        public List<AnalisisDTO> Detalle(int idPersona)
        {
            var laListaDeAnalisis = (from elAnalisis in _elContexto.AnalisisTabla
                                     where elAnalisis.IdPersona == idPersona
                                     select new AnalisisDTO
                                     {
                                         IdAnalisis = elAnalisis.IdAnalisis,
                                         IdPersona = elAnalisis.IdPersona,
                                         NivelDeRiesgoGenerado = elAnalisis.NivelDeRiesgoGenerado,
                                         TotalDePalabrasClaveEncontradas = elAnalisis.TotalDePalabrasClaveEncontradas,
                                         CantidadDeArchivosEmparejados = elAnalisis.CantidadDeArchivosEmparejados,
                                         FechaDeAnalisis = elAnalisis.FechaDeAnalisis.ToString(),
                                         Comentario = elAnalisis.Comentario
                                     }).ToList();

            return laListaDeAnalisis;
        }
    }
}
