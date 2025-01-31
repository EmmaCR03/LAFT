using LAFT.Abstracciones.LN.Interfaces.Analisis.Conversiones;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.Analisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.General.Conversiones.Analisis
{

        public class ConvertirAnalisisDTOAAnalisisTablaLN : IConvertirAnalisisDTOAAnalisisTablaLN
    {
            IFecha _fecha;

            public ConvertirAnalisisDTOAAnalisisTablaLN()
            {
                _fecha = new Fecha();
            }
            public AnalisisTabla Convertir(AnalisisDTO elAnalisis)
            {
                return new AnalisisTabla
                {
                    FechaDeAnalisis = _fecha.ObtenerFecha(),
                    IdAnalisis = elAnalisis.IdAnalisis,
                    IdPersona = elAnalisis.IdPersona,
                    NivelDeRiesgoGenerado = elAnalisis.NivelDeRiesgoGenerado,
                    TotalDePalabrasClaveEncontradas = elAnalisis.TotalDePalabrasClaveEncontradas,
                    Comentario = elAnalisis.Comentario

                };
            }
        }
    
}
