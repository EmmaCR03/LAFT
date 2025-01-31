using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.ObtenerPorID
{
    public interface IObtenerPersonaPorIdAD
    {
        PersonaTabla Obtener(int IdPersona);
    }
}
