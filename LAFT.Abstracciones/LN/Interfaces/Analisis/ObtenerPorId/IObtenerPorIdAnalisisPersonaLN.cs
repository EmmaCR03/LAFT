using LAFT.Abstracciones.Modelos.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.Analisis.ObtenerPorId
{
    public interface IObtenerPorIdAnalisisPersonaLN
    {
        List<AnalisisDTO> Detalle(int idPersona);
    }
}
