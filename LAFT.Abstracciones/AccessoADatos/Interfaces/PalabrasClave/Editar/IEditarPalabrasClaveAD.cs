using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Editar
{
    public interface IEditarPalabrasClaveAD
    {
        Task<int> Editar(PalabrasClaveTabla laPalabraActualizar);
    }
}
