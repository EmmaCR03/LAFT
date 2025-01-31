using LAFT.Abstracciones.LN.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.General
{
    public class Fecha : IFecha
    {
        public DateTime ObtenerFecha()
        {
            return DateTime.Now;
        }
    }
}