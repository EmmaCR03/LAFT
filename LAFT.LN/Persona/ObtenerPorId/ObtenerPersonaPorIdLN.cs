using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.ObtenerPorID;
using LAFT.Abstracciones.LN.Interfaces.Persona.ObtenerPorId;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.Persona.ObtenerPorId;
using LAFT.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.Persona.ObtenerPorId
{
    public class ObtenerPersonaPorIdLN : IObtenerPersonaPorIdLN
    {
        IObtenerPersonaPorIdAD _obtenerPorIdAD;
        Fecha _fecha;
        public ObtenerPersonaPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPersonaPorIdAD();
            _fecha = new Fecha();
        }

        public PersonaDTO Obtener(int idPalabra)
        {
           PersonaTabla personaEnBaseDeDatos = _obtenerPorIdAD.Obtener(idPalabra);
            PersonaDTO laPersonaAMostrar = ConvertirAPersonaAMostrar(personaEnBaseDeDatos);
            return laPersonaAMostrar;
        }
        private PersonaDTO ConvertirAPersonaAMostrar(PersonaTabla personaEnBaseDeDatos)
        {
            return new PersonaDTO
            {
                IdPersona = personaEnBaseDeDatos.IdPersona,
                IdentificacionPersona = personaEnBaseDeDatos.IdentificacionPersona,
                TipoIdentificacion = personaEnBaseDeDatos.TipoIdentificacion,
                NombrePersona = personaEnBaseDeDatos.NombrePersona,
                PrimerApellidoPersona = personaEnBaseDeDatos.PrimerApellidoPersona,
                SegundoApellidoPersona = personaEnBaseDeDatos.SegundoApellidoPersona,
                Telefono = personaEnBaseDeDatos.Telefono,
                CorreoElectronico = personaEnBaseDeDatos.CorreoElectronico,
                Direccion = personaEnBaseDeDatos.Direccion,
                EstadoDeRiesgo = personaEnBaseDeDatos.EstadoDeRiesgo,
                Estado = personaEnBaseDeDatos.Estado,
                FechaDeRegistro = personaEnBaseDeDatos.FechaDeRegistro.ToString(),
                FechaDeModificacion = personaEnBaseDeDatos.FechaDeModificacion.ToString()
            };
        }

    }
}
