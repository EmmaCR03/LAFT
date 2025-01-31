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

namespace LAFT.LN.PalabrasClave.Listar
{
    public class ListarPalabrasClaveLN : IListarPalabrasClaveLN
    {
        IListarPalabraClaveAD _listarPalabraClaveAD;
        public ListarPalabrasClaveLN()
        {
            _listarPalabraClaveAD = new ListarPalabraClaveAD();

        }

        public List<PalabrasClaveDTO> Listar()
        {
            List<PalabrasClaveDTO> laListaDePalabra = _listarPalabraClaveAD.Listar();
            //List<PersonaDTO> laListaDePersonas = ObtenerLaListaConvertida(laListaDePersona);
            return laListaDePalabra;
        }
    }
}
