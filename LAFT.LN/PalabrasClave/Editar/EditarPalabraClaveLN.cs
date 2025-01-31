using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Editar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Conversion;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Editar;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.AccesoADatos.PalabrasClave.Editar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using LAFT.LN.General.Conversiones.PalabrasClave;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace LAFT.LN.PalabrasClave.Editar
{
    public class EditarPalabraClaveLN : IEditarPalabraClaveLN
    {
      IEditarPalabrasClaveAD _editarPalabrasClave;
       IConvertirPalabrasClaveDTOAPalabrasClaveTablaLN _convertir;
         IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
         IFecha _fecha;

        public EditarPalabraClaveLN()
        {
            _editarPalabrasClave = new EditarPalabrasClaveAD();
            _convertir = new ConvertirPalabrasClaveDTOAPalabrasClaveTablaLN();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
            _fecha = new Fecha();
        }

        public async Task<int> Actualizar(PalabrasClaveDTO laPalabraEnVista)
        {
            try
            {
                int cantidadDeDatosActualizados = await _editarPalabrasClave.Editar(_convertir.Convertir(laPalabraEnVista));

                if (cantidadDeDatosActualizados > 0)
                {
                    // Crea un evento para la bitácora
                    var evento = new BitacoraEventosDTO
                    {
                        TablaDeEvento = "PalabraTabla",
                        TipoDeEvento = "Actualización",
                        FechaDeEvento = _fecha.ObtenerFecha().ToString("yyyy-MM-dd HH:mm:ss"),
                        DescripcionDeEvento = $"Se actualizó la persona con ID {laPalabraEnVista.IdPalabra}.",
                        DatosAnteriores = "N/A", // No aplica para este caso
                        DatosPosteriores = JsonConvert.SerializeObject(laPalabraEnVista)
                    };

                    // Registra el evento en la bitácora
                    await _registrarBitacoraEventosLN.RegistrarEvento(
                        evento.TablaDeEvento,
                        evento.TipoDeEvento,
                        evento.DescripcionDeEvento,
                        evento.DatosAnteriores,
                        evento.DatosPosteriores
                    );
                }

                return cantidadDeDatosActualizados;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la persona: {ex.Message}");
                throw; // Relanza la excepción para que sea manejada en niveles superiores
            }
        }
    }
}
