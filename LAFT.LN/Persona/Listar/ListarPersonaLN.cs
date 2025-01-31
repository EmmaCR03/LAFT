using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Listar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.Listar;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Listar;
using LAFT.Abstracciones.LN.Interfaces.Persona;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.PalabrasClave.Listar;
using LAFT.AccesoADatos.Persona.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.Persona.Listar
{
    public class ListarPersonaLN: IListarPersonaLN
    {
        IListarPersonaAD _listarPersona;
        public ListarPersonaLN()
        {
            _listarPersona = new ListarPersonaAD();

        }

        public List<PersonaDTO> Listar()
        {
            List<PersonaDTO> laListaDePersona = _listarPersona.Listar();
            //List<PersonaDTO> laListaDePersonas = ObtenerLaListaConvertida(laListaDePersona);
            return laListaDePersona;
        }
    }
}