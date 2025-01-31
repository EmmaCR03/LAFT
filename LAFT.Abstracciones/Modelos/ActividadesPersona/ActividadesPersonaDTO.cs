using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.Modelos.ActividadesPersona
{
    public class ActividadesPersonaDTO
    {
        [Display(Name = "ID de Actividad Persona", Prompt = "Ingrese el ID de la actividad de la persona", Description = "ID de Actividad Persona")]
        [Required]
        public int IdActividadPersona { get; set; }

        [Display(Name = "ID de Actividad Financiera", Prompt = "Ingrese el ID de la actividad financiera", Description = "ID de Actividad Financiera")]
        [Required]
        public int IdActividadFinanciera { get; set; }

        [Display(Name = "ID de Persona", Prompt = "Ingrese el ID de la persona", Description = "ID de Persona")]
        [Required]
        public int IdPersona { get; set; }

        [Display(Name = "Fecha de Registro", Prompt = "Ingrese la fecha de registro", Description = "Fecha de Registro")]
        [Required]

        public string FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación", Prompt = "Ingrese la fecha de modificación", Description = "Fecha de Modificación")]
        [Required]

        public string FechaDeModificacion { get; set; }

        [Display(Name = "Estado", Prompt = "Ingrese el estado", Description = "Estado")]
        [Required]
        public int NivelDeRiesgo { get; set; }

        public bool Estado { get; set; }

        public string NombreActividadFinanciera { get; set; }
    }
}