using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Registrar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.Crear;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.Persona.Registrar
{
    public class RegistrarPersonaAD : IRegistrarPersonaAD
    {
        Contexto _elContexto;

        public RegistrarPersonaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Guardar(PersonaTabla laActividadPersonaAGuardar)
        {
            try
            {
                _elContexto.PersonaTabla.Add(laActividadPersonaAGuardar);
                EntityState estado = _elContexto.Entry(laActividadPersonaAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error en el log o hacer un seguimiento
                Console.WriteLine("Error al guardar la persona: " + ex.Message);
                return 0;
            }
        }

    }
}
