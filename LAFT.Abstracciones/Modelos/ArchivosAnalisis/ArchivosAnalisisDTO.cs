using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.Modelos.ArchivosAnalisis
{
    public class ArchivosAnalisisDTO
    {
        [Display(Name = "ID del Archivo", Prompt = "Ingrese el ID del archivo", Description = "ID del Archivo")]
        [Required]
        public int IdArchivo { get; set; }

        [Display(Name = "Nombre", Prompt = "Ingrese el nombre", Description = "Nombre asociado al archivo")]
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        [Display(Name = "Texto del Archivo", Prompt = "Ingrese el texto del archivo", Description = "Texto del Archivo")]
        [Required]
        [MaxLength(1000)]
        public string TextoDelArchivo { get; set; }

        [Display(Name = "Fuente", Prompt = "Ingrese la fuente", Description = "Fuente de donde proviene el archivo o su contenido")]
        [Required]
        [MaxLength(300)]
        public string Fuente { get; set; }

        [Display(Name = "Fecha de Registro", Prompt = "Ingrese la fecha de registro", Description = "Fecha de Registro")]
        [Required]

        public string FechaDeRegistro { get; set; }
    }
}
