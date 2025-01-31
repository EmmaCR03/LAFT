using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Registrar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Registrar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.ActividadesPersona;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using LAFT.AccesoADatos.ActividadesPersona.Registrar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesPersona.Registrar
{
    public class RegistrarActividadesPersonaLN : IRegistrarActividadesPersonaLN
    {
        // Dependencias
        private readonly IRegistrarActividadesPersonaAD _registrarActividadesPersonaAD;
        private readonly IFecha _fecha;
        private readonly IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;

        // Constructor
        public RegistrarActividadesPersonaLN()
        {
            _fecha = new Fecha();
            _registrarActividadesPersonaAD = new RegistrarActividadesPersonaAD();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
        }

        // Método para guardar actividades de persona
        public async Task<int> Guardar(ActividadesPersonaDTO modelo, string folderPath)
        {
            try
            {
                // Guarda el registro en la base de datos
                int resultado = await _registrarActividadesPersonaAD.Guardar(ConvertirObjetoActividadesPersonaTabla(modelo));

                if (resultado > 0)
                {
                    // Crea un evento para la bitácora
                    var evento = new BitacoraEventosDTO
                    {
                        TablaDeEvento = "ActividadesPersonaTabla",
                        TipoDeEvento = "Registro",
                        FechaDeEvento = _fecha.ObtenerFecha().ToString("yyyy-MM-dd HH:mm:ss"),
                        DescripcionDeEvento = $"Se registró la actividad con ID {modelo.IdActividadPersona}.",
                        DatosAnteriores = "N/A", // No aplica para registros nuevos
                        DatosPosteriores = JsonConvert.SerializeObject(modelo)
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

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la actividad: {ex.Message}");
                throw; // Relanza la excepción para que pueda manejarse en niveles superiores
            }
        }

        // Método para convertir el DTO en una tabla compatible con la base de datos
        private ActividadesPersonaTabla ConvertirObjetoActividadesPersonaTabla(ActividadesPersonaDTO laActividadesPersona)
        {
            return new ActividadesPersonaTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                Estado = laActividadesPersona.Estado,
                IdActividadPersona = laActividadesPersona.IdActividadPersona,
                IdPersona = laActividadesPersona.IdPersona,
                IdActividadFinanciera = laActividadesPersona.IdActividadFinanciera
            };
        }
    }
}
