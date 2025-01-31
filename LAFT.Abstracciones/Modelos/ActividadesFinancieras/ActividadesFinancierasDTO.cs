using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.Modelos.ActividadesFinancieras
{
    public class ActividadesFinancierasDTO
    {

        [Display(Name = "ID de Actividad Financiera", Prompt = "Ingrese el ID de la actividad financiera", Description = "ID de Actividad Financiera")]
        [Required]
        public int IdActividadFinanciera { get; set; }

        [Display(Name = "Nombre de la Actividad Financiera", Prompt = "Ingrese el nombre de la actividad financiera", Description = "Nombre de la actividad financiera")]
        [Required]
        [MaxLength(200)]
        public string NombreActividadFinanciera { get; set; }

        [Display(Name = "Descripción de la Actividad Financiera", Prompt = "Ingrese la descripción de la actividad financiera", Description = "Descripción de la actividad financiera")]
        [Required]
        [MaxLength(500)]
        public string DescripcionActividadFinanciera { get; set; }

        [Display(Name = "Nivel de Riesgo", Prompt = "Ingrese el nivel de riesgo", Description = "Nivel de riesgo")]
        [Required]
        public int NivelDeRiesgo { get; set; }

        [Display(Name = "Fecha de Registro", Prompt = "Ingrese la fecha de registro", Description = "Fecha de Registro")]
        [Required]

        public string FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación", Prompt = "Ingrese la fecha de modificación", Description = "Fecha de Modificación")]
        [Required]

        public string FechaDeModificacion { get; set; }

        [Display(Name = "Estado", Prompt = "Ingrese el estado", Description = "Estado actual de la actividad financiera")]
        [Required]
        public bool Estado { get; set; }
    }
}

