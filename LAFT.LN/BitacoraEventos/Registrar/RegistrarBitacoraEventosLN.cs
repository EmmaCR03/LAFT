using LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos.Bitacora;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.AccesoADatos.BitacoraEventos.Registrar;
using LAFT.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.LN.General;

namespace LAFT.LN.BitacoraEventos.Registrar
{
    public class RegistrarBitacoraEventosLN : IRegistrarBitacoraEventosLN
    {
        IRegistrarBitacoraServiceAD _bitacoraServiceAD;
        IFecha _fecha;

        public RegistrarBitacoraEventosLN()
        {
            _bitacoraServiceAD = new RegistrarBitacoraEventosAD();
            _fecha = new Fecha();
        }

        public async Task RegistrarEvento(string tabla, string tipoEvento, string descripcion, string datosAnteriores = "N/A", string datosPosteriores = "N/A")
        {
            // Validaciones o transformaciones del evento
            var evento = new BitacoraEventosTabla
            {
                TablaDeEvento = tabla,
                TipoDeEvento = tipoEvento,
                FechaDeEvento = _fecha.ObtenerFecha(),
                StackTrace = "N/A",
                DescripcionDeEvento = descripcion,
                DatosAnteriores = datosAnteriores,
                DatosPosteriores = datosPosteriores
            };
            await _bitacoraServiceAD.RegistrarEvento(evento);
        }

    }
}