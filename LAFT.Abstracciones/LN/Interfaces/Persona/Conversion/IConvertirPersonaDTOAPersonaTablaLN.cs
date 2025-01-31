using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.Persona.Conversion
{
    public interface IConvertirPersonaDTOAPersonaTablaLN
    {
        PersonaTabla Convertir(PersonaDTO laPersona);
    }
}
