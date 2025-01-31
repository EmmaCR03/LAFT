using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras
{
    public interface IListarActividadesFinancierasAD
    {
        List<ActividadesFinancierasDTO> Listar();
    }
}
