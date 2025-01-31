using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace LAFT.Abstracciones.Modelos.BitacoraEventos
{
    public class BitacoraEventosDTO
    {
        [Display(Name = "ID del Evento", Prompt = "Ingrese el ID del evento", Description = "ID del Evento")]
        [Required]
        public int IdEvento { get; set; }

        [Display(Name = "Tabla del Evento", Prompt = "Ingrese el nombre de la tabla afectada", Description = "Nombre de la tabla relacionada con el evento")]
        [Required]
        [MaxLength(100)]
        public string TablaDeEvento { get; set; }

        [Display(Name = "Tipo de Evento", Prompt = "Ingrese el tipo de evento", Description = "Tipo de evento")]
        [Required]
        [MaxLength(100)]
        public string TipoDeEvento { get; set; }

        [Display(Name = "Fecha de Evento", Prompt = "Ingrese la fecha del evento", Description = "Fecha de evento")]
        [Required]

        public string FechaDeEvento { get; set; }

        [Display(Name = "Descripción del Evento", Prompt = "Ingrese una descripción del evento", Description = "Descripción detallada del evento")]
        [Required]
        [MaxLength(500)]
        public string DescripcionDeEvento { get; set; }

        [Display(Name = "Stack Trace", Prompt = "Ingrese el stack trace", Description = "Stack Trace")]
        [Required]
        [MaxLength(1000)]
        public string StackTrace { get; set; }

        [Display(Name = "Datos Anteriores", Prompt = "Ingrese los datos antes del evento", Description = "Estado de los datos anteriores del evento")]
        [Required]
        [MaxLength(1000)]
        public string DatosAnteriores { get; set; }

        [Display(Name = "Datos Posteriores", Prompt = "Ingrese los datos después del evento", Description = "Estado de los datos posteriores del evento")]
        [Required]
        [MaxLength(1000)]
        public string DatosPosteriores { get; set; }
    }
}
