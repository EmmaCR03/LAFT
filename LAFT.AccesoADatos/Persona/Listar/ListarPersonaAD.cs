using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.Listar;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.Persona.Listar
{
    public class ListarPersonaAD : IListarPersonaAD
    {
        Contexto _elContexto;

        public ListarPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public List<PersonaDTO> Listar()
        {
            List<PersonaDTO> laListaDePersona = (from laPersona in _elContexto.PersonaTabla
                                                 select new PersonaDTO
                                                 {
                                                     FechaDeRegistro = laPersona.FechaDeRegistro.ToString(),
                                                     FechaDeModificacion = laPersona.FechaDeModificacion.ToString(),
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
                                                 }

                                                 ).ToList();
            return laListaDePersona;

        }
    }
}