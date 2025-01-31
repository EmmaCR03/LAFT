using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.ObtenerPorId
{
    public interface IObtenerPorIdAD
    {
        ActividadesPersonaTabla Obtener(int id);
    }
}
