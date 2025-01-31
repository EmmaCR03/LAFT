using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using LAFT.AccesoADatos.ArchivosAnalisis.Registrar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using Microsoft.Build.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ArchivosAnalisis.Registrar
{
    public class RegistrarArchivosAnalisisLN : IRegistrarArchivosAnalisisLN
    {
        IRegistrarArchivosAnalisisAD _registrarArchivos;
        IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;

        IFecha _fecha;
        public RegistrarArchivosAnalisisLN()
        {
            _registrarArchivos = new RegistrarArchivosAnalisisAD();
            _fecha = new Fecha();
        }

        public async Task<int> Guardar(ArchivosAnalisisDTO modelo, string folderPath)
        {
            if (modelo == null)
            {
                throw new ArgumentException("El modelo no puede ser nulo.");
            }
            try
            {
                var datosPosteriores = ConvertirObjetoArchivosAnalisisTabla(modelo);

                // Guardar los datos en la base de datos
                int resultado = await _registrarArchivos.Guardar(datosPosteriores);

                // Si se guarda correctamente, registrar en la bitácora
               
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar la persona: {ex.Message}");
                throw; // Relanzar la excepción
            }
        }

        private ArchivosAnalisisTabla ConvertirObjetoArchivosAnalisisTabla(ArchivosAnalisisDTO ElArchivo)
        {
            return new ArchivosAnalisisTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                IdArchivo = ElArchivo.IdArchivo,
                Nombre = ElArchivo.Nombre,
                TextoDelArchivo = ElArchivo.TextoDelArchivo,
                Fuente = ElArchivo.Fuente

            };
        }
    }
}

