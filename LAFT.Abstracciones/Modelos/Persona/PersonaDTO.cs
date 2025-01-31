using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.Modelos.Persona
{
    public class PersonaDTO
    {
        [Display(Name = "ID Persona", Prompt = "Ingrese el ID", Description = "Identificación única de la persona asociada")]
        [Required]
        public int IdPersona { get; set; }

        [Display(Name = "Identificación", Prompt = "Ingrese la identificación", Description = "Identificación")]
        [Required]
        public string IdentificacionPersona { get; set; }

        [Display(Name = "Tipo de identificación", Prompt = "Ingrese el Tipo de identificación", Description = "Tipo de identificación")]
        [Required]
        public int TipoIdentificacion { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nombre", Prompt = "Ingrese el Nombre", Description = "Nombre")]
        [Required]
        public string NombrePersona { get; set; }

        [MaxLength(100)]
        [Display(Name = "Primer apellido", Prompt = "Ingrese el primer apellido", Description = "Primer apellido")]
        [Required]
        public string PrimerApellidoPersona { get; set; }

        [MaxLength(100)]
        [Display(Name = "Segundo apellido", Prompt = "Ingrese el Segundo apellido", Description = "Segundo apellido")]
        [Required]
        public string SegundoApellidoPersona { get; set; }

        [MaxLength(20)]
        [Display(Name = "Teléfono", Prompt = "Ingrese el Teléfono", Description = "Teléfono")]
        [Required]
        public string Telefono { get; set; }

        [MaxLength(200)]
        [Display(Name = "Correo Electrónico", Prompt = "Ingrese el Correo Electrónico", Description = "Correo Electrónico")]
        [Required]
        public string CorreoElectronico { get; set; }

        [MaxLength(500)]
        [Display(Name = "Dirección", Prompt = "Ingrese la Dirección", Description = "Dirección")]
        [Required]
        public string Direccion { get; set; }

        [Display(Name = "Estado De Riesgo", Prompt = "Ingrese el Estado De Riesgo", Description = "Estado De Riesgo")]
        [Required]
        public int EstadoDeRiesgo { get; set; }

        [Display(Name = "Fecha de Registro", Prompt = "Ingrese la fecha de registro", Description = "Fecha de Registro")]
        [Required]
        public string FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación", Prompt = "Ingrese la fecha de modificación", Description = "Fecha de modificación")]
        [Required]
        public string FechaDeModificacion { get; set; }

        [Display(Name = "Estado", Prompt = "Ingrese el estado", Description = "Estado actual del registro")]
        [Required]
        public bool Estado { get; set; }
    }
}
