using LAFT.Abstracciones.Modelos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Listar
{
    public interface IListarPalabraClaveAD
    {
        List<PalabrasClaveDTO> Listar();
    }
}
