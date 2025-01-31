using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.Editar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Conversiones;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Editar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.AccesoADatos.ActividadesFinancieras.Editar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using LAFT.LN.General.Conversiones.ActividadesFinancieras;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesFinancieras.Editar
{
    public class EditarActividadesFinancierasLN : IEditarActividadesFinancierasLN
    {
      IEditarActividadesFinancierasAD _editarActividadesFinancieras;
      IConvertirActividadesFinancierasDTOAActividadesFinancierasTablaLN _convertir;
       IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
         IFecha _fecha;

        public EditarActividadesFinancierasLN()
        {
            _editarActividadesFinancieras = new EditarActividadesFinancierasAD();
            _convertir = new ConvertirActividadesFinancierasDTOAActividadesFinancierasTablaLN();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
            _fecha = new Fecha();
        }

        public async Task<int> Actualizar(ActividadesFinancierasDTO laActividadFEnVista)
        {
            try
            {
                int cantidadDeDatosActualizados = await _editarActividadesFinancieras.Editar(_convertir.Convertir(laActividadFEnVista));

                if (cantidadDeDatosActualizados > 0)
                {
                    // Crea un evento para la bitácora
                    var evento = new BitacoraEventosDTO
                    {
                        TablaDeEvento = "ActividadesFinancierasTabla",
                        TipoDeEvento = "Actualización",
                        FechaDeEvento = _fecha.ObtenerFecha().ToString("yyyy-MM-dd HH:mm:ss"),
                        DescripcionDeEvento = $"Se actualizó la actividad con ID {laActividadFEnVista.IdActividadFinanciera}.",
                        DatosAnteriores = "N/A", // No aplica para este caso
                        DatosPosteriores = JsonConvert.SerializeObject(laActividadFEnVista)
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
                Console.WriteLine($"Error al actualizar la actividad: {ex.Message}");
                throw; // Relanza la excepción para que sea manejada en niveles superiores
            }
        }
    }
}
