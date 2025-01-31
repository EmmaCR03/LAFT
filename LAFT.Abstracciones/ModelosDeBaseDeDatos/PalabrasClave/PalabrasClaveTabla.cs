using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave
{
    [Table("PalabrasClave")]
    public class PalabrasClaveTabla
    {
        [Key]
        public int IdPalabra { get; set; }
        public string Palabra { get; set; }
        public int Orden { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
