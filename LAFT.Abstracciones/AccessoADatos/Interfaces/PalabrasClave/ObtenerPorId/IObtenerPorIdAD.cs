using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.ObtenerPorId
{
    public interface IObtenerPorIdAD
    {
        PalabrasClaveTabla Obtener(int id);
    }
}
