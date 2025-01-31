using LAFT.Abstracciones.Modelos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Listar
{
    public interface IListarBitacoraEventosLN
    {
        List<BitacoraEventosDTO> ListarBitacora();
    }
}
