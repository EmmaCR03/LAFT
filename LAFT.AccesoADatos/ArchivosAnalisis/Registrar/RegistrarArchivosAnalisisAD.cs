using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.Registrar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ArchivosAnalisis.Registrar
{
    public class RegistrarArchivosAnalisisAD : IRegistrarArchivosAnalisisAD
    {
        Contexto _elContexto;

        public RegistrarArchivosAnalisisAD() 
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Guardar(ArchivosAnalisisTabla elArchivoAGuardar)
        {
            try
            {
                _elContexto.ArchivosAnalisisTabla.Add(elArchivoAGuardar);
                EntityState estado = _elContexto.Entry(elArchivoAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}