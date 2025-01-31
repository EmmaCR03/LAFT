using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.PalabrasClave.ObtenerPorId
{
    public interface IObtenerPorIdLN
    {
        PalabrasClaveDTO Obtener(int idPalabra);
    }
}
