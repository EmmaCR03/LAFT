using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.Modelos.Analisis
{
    public class PersonaAnalizadaDto
    {
        
        public int IdPersona { get; set; }
        [Display(Name = "Tipo de Identificación")]
        public int TipoIdentificacion { get; set; }
        [Display(Name = "Nombre de la Persona")]
        public string NombrePersona { get; set; }
        [Display(Name = "Primer Apellido")]
        public string PrimerApellidoPersona { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellidoPersona { get; set; }
        [Display(Name = "Estado de Riesgo")]
        public int NivelDeRiesgoGenerado { get; set; }
        [Display(Name = "Fecha del Último Análisis")]
        public DateTime FechaDeAnalisis { get; set; }
    }

}
