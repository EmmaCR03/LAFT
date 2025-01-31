using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.ObtenerPorId
{
    public interface IObtenerPorIdLN
    {
        ActividadesFinancierasDTO Obtener(int id);
    }
}
