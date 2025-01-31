using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.Crear;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.Persona.Registrar;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.Persona.Registrar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.Persona.Registrar
{
    public class RegistrarPersonaLN : IRegistrarPersonaLN
    {
        IRegistrarPersonaAD _registrarPersonaAD;
        IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
        IFecha _fecha;

        public RegistrarPersonaLN()
        {
            // Crear las instancias necesarias
            _registrarPersonaAD = new RegistrarPersonaAD();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
            _fecha = new Fecha();
        }

        public async Task<int> Guardar(PersonaDTO modelo, string folderPath)
        {
            if (modelo == null)
            {
                throw new ArgumentException("El modelo no puede ser nulo.");
            }

            try
            {
                var datosPosteriores = ConvertirObjetoPersonaTabla(modelo);

                // Guardar los datos en la base de datos
                int resultado = await _registrarPersonaAD.Guardar(datosPosteriores);

                // Si se guarda correctamente, registrar en la bitácora
                if (resultado > 0)
                {
                    var evento = new BitacoraEventosDTO
                    {
                        TablaDeEvento = "PersonaTabla",
                        TipoDeEvento = "Registro",
                        FechaDeEvento = _fecha.ObtenerFecha().ToString("yyyy-MM-dd HH:mm:ss"),
                        DescripcionDeEvento = $"Se registró la persona con ID {modelo.IdPersona}.",
                        DatosAnteriores = "N/A", // No aplica para registros nuevos,
                        DatosPosteriores = JsonConvert.SerializeObject(datosPosteriores)
                    };

                    // Registrar el evento en la bitácora
                    await _registrarBitacoraEventosLN.RegistrarEvento(
                        evento.TablaDeEvento,
                        evento.TipoDeEvento,
                        evento.DescripcionDeEvento,
                        evento.DatosAnteriores,
                        evento.DatosPosteriores
                    );
                }

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la persona: {ex.Message}");
                throw; // Relanzar la excepción
            }
        }

        private PersonaTabla ConvertirObjetoPersonaTabla(PersonaDTO laPersona)
        {
            return new PersonaTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdentificacionPersona = laPersona.IdentificacionPersona,
                TipoIdentificacion = laPersona.TipoIdentificacion,
                NombrePersona = laPersona.NombrePersona,
                Estado = laPersona.Estado,
                PrimerApellidoPersona = laPersona.PrimerApellidoPersona,
                SegundoApellidoPersona = laPersona.SegundoApellidoPersona,
                Telefono = laPersona.Telefono,
                CorreoElectronico = laPersona.CorreoElectronico,
                Direccion = laPersona.Direccion,
                EstadoDeRiesgo = laPersona.EstadoDeRiesgo,
                IdPersona = laPersona.IdPersona
            };


        }
    }
}
