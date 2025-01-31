using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.Modelos.PalabrasClave
{
    public class PalabrasClaveDTO
    {
        [Display(Name = "ID de Palabra", Prompt = "Ingrese el ID de la palabra", Description = "ID de Palabra")]
        [Required]
        public int IdPalabra { get; set; }

        [Display(Name = "Palabra", Prompt = "Ingrese la palabra", Description = "Texto de la palabra a registrar")]
        [Required]
        [MaxLength(100)]
        public string Palabra { get; set; }

        [Display(Name = "Orden", Prompt = "Ingrese el orden de la palabra", Description = "Orden en que se debe mostrar la palabra")]
        [Required]
        public int Orden { get; set; }

        [Display(Name = "Fecha de Registro", Prompt = "Ingrese la fecha de registro", Description = "Fecha en la que se registró la palabra")]
        [Required]
        public string FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación", Prompt = "Ingrese la fecha de modificación", Description = "Fecha en la que se modificó la palabra")]
        [Required]
        public string FechaDeModificacion { get; set; }

        [Display(Name = "Estado", Prompt = "Ingrese el estado", Description = "Estado actual de la palabra (activo o inactivo)")]
        [Required]
        public bool Estado { get; set; }
    }
}
