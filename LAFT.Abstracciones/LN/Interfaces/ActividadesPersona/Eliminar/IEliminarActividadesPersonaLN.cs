using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Eliminar
{
    public interface IEliminarActividadesPersonaLN
    {

        Task<int> Eliminar(int IdActividadPersona);   
    }
}
