using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Conversiones
{
    public interface IConvertirActividadesFinancierasDTOAActividadesFinancierasTablaLN
    {
        ActividadesFinancierasTabla Convertir(ActividadesFinancierasDTO laActividadF);
    }
}
