using LAFT.Abstracciones.Modelos.Analisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.Analisis.Conversiones
{
    public interface IConvertirAnalisisDTOAAnalisisTablaLN
    {
        AnalisisTabla Convertir(AnalisisDTO elAnalisis);
    }
}
