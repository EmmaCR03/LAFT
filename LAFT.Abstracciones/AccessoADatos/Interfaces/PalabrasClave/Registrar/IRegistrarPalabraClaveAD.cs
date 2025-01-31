using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Registrar
{
    public interface IRegistrarPalabraClaveAD
    {
        Task<int> Guardar(PalabrasClaveTabla laPalabraClaveAGuardar);
    }
}
