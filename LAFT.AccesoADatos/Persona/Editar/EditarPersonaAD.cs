using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.Editar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.Persona.Editar
{
    public class EditarPersonaAD: IEditarPersonaAD
    {
        Contexto _elContexto;

        public EditarPersonaAD() 
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(PersonaTabla laPersonaActualizar) 
        {
            PersonaTabla laPersonaEnBaseDeDatos = _elContexto.PersonaTabla.Where(laPersona => laPersona.IdPersona == laPersonaActualizar.IdPersona).FirstOrDefault();
            laPersonaEnBaseDeDatos.NombrePersona = laPersonaActualizar.NombrePersona;
            laPersonaEnBaseDeDatos.PrimerApellidoPersona = laPersonaActualizar.PrimerApellidoPersona;
            laPersonaEnBaseDeDatos.SegundoApellidoPersona = laPersonaActualizar.SegundoApellidoPersona;
            laPersonaEnBaseDeDatos.Telefono = laPersonaActualizar.Telefono;
            laPersonaEnBaseDeDatos.CorreoElectronico = laPersonaActualizar.CorreoElectronico;
            laPersonaEnBaseDeDatos.Direccion = laPersonaActualizar.Direccion;
            laPersonaEnBaseDeDatos.FechaDeModificacion = laPersonaActualizar.FechaDeModificacion;
            EntityState estado = _elContexto.Entry(laPersonaEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}