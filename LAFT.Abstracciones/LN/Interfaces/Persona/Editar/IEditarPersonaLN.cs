using LAFT.Abstracciones.Modelos.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.Persona.Editar
{
    public interface IEditarPersonaLN
    {
        Task<int> Actualizar(PersonaDTO laPersonaEnVista);
    }
}
