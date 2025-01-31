using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.ObtenerPorId
{
    public interface IObtenerPorIdAD
    {
        ActividadesFinancierasTabla Obtener(int id);
    }
}
