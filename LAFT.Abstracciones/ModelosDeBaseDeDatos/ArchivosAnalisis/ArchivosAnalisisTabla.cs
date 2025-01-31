using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis
{
    [Table("Archivos_Analisis")]
    public class ArchivosAnalisisTabla
    {
        [Key]
        public int IdArchivo { get; set; }
        public string Nombre { get; set; }
        public string TextoDelArchivo { get; set; }
        public string Fuente { get; set; }
        public DateTime FechaDeRegistro { get; set; }
    }
}
