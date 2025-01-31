using LAFT.Abstracciones.Modelos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Editar
{
    public interface IEditarPalabraClaveLN
    {
        Task<int> Actualizar(PalabrasClaveDTO laPalabraEnVista);
    }
}
