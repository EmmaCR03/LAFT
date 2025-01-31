using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.Persona.Conversion;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.General.Conversiones.Persona
{
    public class ConvertirPersonaDTOAPersonaTablaLN : IConvertirPersonaDTOAPersonaTablaLN
    {
        IFecha _fecha;

        public ConvertirPersonaDTOAPersonaTablaLN()
        {
            _fecha = new Fecha();
        }
        public PersonaTabla Convertir(PersonaDTO laPersona)
        {
            return new PersonaTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdPersona = laPersona.IdPersona,
                IdentificacionPersona = laPersona.IdentificacionPersona,
                TipoIdentificacion = laPersona.TipoIdentificacion,
                NombrePersona = laPersona.NombrePersona,
                PrimerApellidoPersona = laPersona.PrimerApellidoPersona,
                SegundoApellidoPersona = laPersona.SegundoApellidoPersona,
                Telefono = laPersona.Telefono,
                CorreoElectronico = laPersona.CorreoElectronico,
                Direccion = laPersona.Direccion,
                EstadoDeRiesgo = laPersona.EstadoDeRiesgo,
                Estado = laPersona.Estado
               
            };
        }
    }
}