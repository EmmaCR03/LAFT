using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Registrar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Registrar;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using LAFT.AccesoADatos.PalabrasClave.Registrar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.PalabrasClave.Registrar
{
    public class RegistrarPalabraClaveLN : IRegistrarPalabraClaveLN
    {
        IRegistrarPalabraClaveAD _registrarPalabraClaveAD;
        IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
        IFecha _fecha;

        public RegistrarPalabraClaveLN()
        {
            _registrarPalabraClaveAD = new RegistrarPalabraClaveAD();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
            _fecha = new Fecha();
        }

        public async Task<int> Guardar(PalabrasClaveDTO modelo, string folderPath)
        {
           
            try
            {
                var datosPosteriores = ConvertirObjetoPalabraTabla(modelo);

                if (modelo.Estado == null)
                {
                    modelo.Estado = true; // Activa por defecto
                }
                // Guardar los datos en la base de datos
                int resultado = await _registrarPalabraClaveAD.Guardar(datosPosteriores);




                if (resultado > 0)
                {
                    var evento = new BitacoraEventosDTO
                    {
                        TablaDeEvento = "PalabraTabla",
                        TipoDeEvento = "Registro",
                        FechaDeEvento = _fecha.ObtenerFecha().ToString("yyyy-MM-dd HH:mm:ss"),
                        DescripcionDeEvento = $"Se registró la palabra con ID {modelo.IdPalabra}.",
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
        private PalabrasClaveTabla ConvertirObjetoPalabraTabla(PalabrasClaveDTO laPalabraClave)
        {
            return new PalabrasClaveTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdPalabra = laPalabraClave.IdPalabra,
                Palabra = laPalabraClave.Palabra,
                Orden = laPalabraClave.Orden,
                Estado = laPalabraClave.Estado
            };
        }
    }
}