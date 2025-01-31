using LAFT.Abstracciones.Modelos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar
{
    public interface IRegistrarBitacoraEventosLN
    {
        Task RegistrarEvento(string tabla, string tipoEvento, string descripcion, string datosAnteriores = "N/A", string datosPosteriores = "N/A");
    }
}
