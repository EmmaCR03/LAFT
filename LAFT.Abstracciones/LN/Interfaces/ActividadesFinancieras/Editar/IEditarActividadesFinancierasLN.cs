using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Editar
{
    public interface IEditarActividadesFinancierasLN
    {
        Task<int> Actualizar(ActividadesFinancierasDTO laActividadFEnVista);
    }
}
