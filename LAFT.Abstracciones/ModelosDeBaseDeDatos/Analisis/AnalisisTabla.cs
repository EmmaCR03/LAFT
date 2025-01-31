using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis
{
    [Table("Analisis_Persona")]
    public class AnalisisTabla
    {
        [Key]
        public int IdAnalisis { get; set; }
        public int IdPersona { get; set; }
        public int NivelDeRiesgoGenerado { get; set; }
        public int TotalDePalabrasClaveEncontradas { get; set; }
        public int CantidadDeArchivosEmparejados { get; set; }
        public DateTime FechaDeAnalisis { get; set; }
        public string Comentario { get; set; }
    }
}
