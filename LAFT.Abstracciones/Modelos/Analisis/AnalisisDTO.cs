using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.Modelos.Analisis
{
    public class AnalisisDTO
    {
        [Display(Name = "ID de Análisis", Prompt = "Ingrese el ID del análisis", Description = "ID del Análisis")]
        [Required]
        public int IdAnalisis { get; set; }

        [Display(Name = "ID de Persona", Prompt = "Ingrese el ID de la persona", Description = "Identificación de la persona asociada")]
        [Required]
        public int IdPersona { get; set; }

        [Display(Name = "Nivel de Riesgo Generado", Prompt = "Ingrese el nivel de riesgo generado", Description = "Nivel de riesgo  a partir del análisis")]
        [Required]
        public int NivelDeRiesgoGenerado { get; set; }

        [Display(Name = "Total de Palabras Clave Encontradas", Prompt = "Ingrese el total de palabras clave encontradas", Description = "Cantidad total de palabras clave identificadas en el análisis")]
        [Required]
        public int TotalDePalabrasClaveEncontradas { get; set; }

        [Display(Name = "Total de Cantidad De Archivos Emparejados", Prompt = "Ingrese el total de Archivos Encontrados", Description = "Cantidad total de Archivos Encontrados")]
        [Required]
        public int CantidadDeArchivosEmparejados { get; set; }

        [Display(Name = "Fecha de Análisis", Prompt = "Ingrese la fecha del análisis", Description = "Fecha en la que se realizó el análisis")]
        [Required]

        public string FechaDeAnalisis { get; set; }

        [Display(Name = "Comentario", Prompt = "Ingrese un comentario", Description = "Comentario relacionado con el análisis")]
        [Required]
        [MaxLength(500)]
        public string Comentario { get; set; }
    }
}
