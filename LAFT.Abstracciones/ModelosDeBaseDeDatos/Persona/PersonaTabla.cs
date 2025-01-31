using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona
{
    [Table("Persona")]
    public class PersonaTabla
    {
        [Key]
        public int IdPersona { get; set; }
        public string IdentificacionPersona { get; set; }
        public int TipoIdentificacion { get; set; }
        public string NombrePersona { get; set; }
        public string PrimerApellidoPersona { get; set; }
        public string SegundoApellidoPersona { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public int EstadoDeRiesgo { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
