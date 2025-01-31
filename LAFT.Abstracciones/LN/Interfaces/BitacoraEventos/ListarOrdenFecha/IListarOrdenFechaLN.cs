using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.ListarOrdenFecha
{
    public interface IListarOrdenFechaLN
    {
        List<BitacoraEventosTabla> ListarEventos();
    }
}
