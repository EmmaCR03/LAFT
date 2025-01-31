using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona
{
    [Table("Actividad_Persona")]
    public class ActividadesPersonaTabla
    {
        [Key]
        public int IdActividadPersona { get; set; }
        public int IdActividadFinanciera { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}