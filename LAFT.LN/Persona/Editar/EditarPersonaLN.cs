using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.Editar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.Persona.Conversion;
using LAFT.Abstracciones.LN.Interfaces.Persona.Editar;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.AccesoADatos.Persona.Editar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using LAFT.LN.General.Conversiones.Persona;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace LAFT.LN.Persona.Editar
{
    public class EditarPersonaLN : IEditarPersonaLN
    {
        private readonly IEditarPersonaAD _editarPersona;
        private readonly IConvertirPersonaDTOAPersonaTablaLN _convertir;
        private readonly IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
        private readonly IFecha _fecha;

        public EditarPersonaLN()
        {
            _editarPersona = new EditarPersonaAD();
            _convertir = new ConvertirPersonaDTOAPersonaTablaLN();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
            _fecha = new Fecha();
        }

        public async Task<int> Actualizar(PersonaDTO laPersonaEnVista)
        {
            try
            {
                int cantidadDeDatosActualizados = await _editarPersona.Editar(_convertir.Convertir(laPersonaEnVista));

                if (cantidadDeDatosActualizados > 0)
                {
                    // Crea un evento para la bitácora
                    var evento = new BitacoraEventosDTO
                    {
                        TablaDeEvento = "PersonaTabla",
                        TipoDeEvento = "Actualización",
                        FechaDeEvento = _fecha.ObtenerFecha().ToString("yyyy-MM-dd HH:mm:ss"),
                        DescripcionDeEvento = $"Se actualizó la persona con ID {laPersonaEnVista.IdPersona}.",
                        DatosAnteriores = "N/A", // No aplica para este caso
                        DatosPosteriores = JsonConvert.SerializeObject(laPersonaEnVista)
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
