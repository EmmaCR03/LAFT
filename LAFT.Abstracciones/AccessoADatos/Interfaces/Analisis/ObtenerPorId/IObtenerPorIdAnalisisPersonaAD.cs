using LAFT.Abstracciones.Modelos.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.ObtenerPorId
{
    public interface IObtenerPorIdAnalisisPersonaAD
    {
        List<AnalisisDTO> Detalle(int idPersona);
    }
}
