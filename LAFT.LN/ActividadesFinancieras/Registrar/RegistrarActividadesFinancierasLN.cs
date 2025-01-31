using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.Registrar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Registrar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using LAFT.AccesoADatos.ActividadesFinancieras.Registrar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesFinancieras.Registrar
{
    public class RegistrarActividadesFinancierasLN : IRegistrarActividadesFinancierasLN
    {
        IRegistrarActividadesFinancierasAD _registrarActividadesFinancierasAD;
        IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
        IFecha _fecha;

        public RegistrarActividadesFinancierasLN()
        {

            _registrarActividadesFinancierasAD = new RegistrarActividadesFinancierasAD();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
            _fecha = new Fecha();

        }

        public async Task<int> Guardar(ActividadesFinancierasDTO modelo, string folderPath)
        {
            if (modelo == null)
            {
                throw new ArgumentException("El modelo no puede ser nulo.");
            }
            try
            {
                var datosPosteriores = ConvertirObjetoActividadesFinancierasTabla(modelo);

                                            
                // Guardar los datos en la base de datos
                int resultado = await _registrarActividadesFinancierasAD.Guardar(datosPosteriores);

                if (resultado > 0)
                {
                    var evento = new BitacoraEventosDTO
                    {
                        TablaDeEvento = "ActividadesFinancierasTabla",
                        TipoDeEvento = "Registro",
                        FechaDeEvento = _fecha.ObtenerFecha().ToString("yyyy-MM-dd HH:mm:ss"),
                        DescripcionDeEvento = $"Se registró la actividad financiera con ID {modelo.IdActividadFinanciera}.",
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
                Console.WriteLine($"Error al guardar la actividad: {ex.Message}");
                throw; // Relanzar la excepción
            }
        }

        private ActividadesFinancierasTabla ConvertirObjetoActividadesFinancierasTabla(ActividadesFinancierasDTO laActividadF)
        {
            return new ActividadesFinancierasTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdActividadFinanciera = laActividadF.IdActividadFinanciera,
                NombreActividadFinanciera = laActividadF.NombreActividadFinanciera,
                DescripcionActividadFinanciera = laActividadF.DescripcionActividadFinanciera,
                NivelDeRiesgo = laActividadF.NivelDeRiesgo,
                Estado = laActividadF.Estado

            };
        }
    }
}