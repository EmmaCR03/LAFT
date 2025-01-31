using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.Editar
{
    public interface IEditarActividadesFinancierasAD
    {
        Task<int> Editar(ActividadesFinancierasTabla laActividadFActualizar);
    }
}
