using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.ObtenerPorID;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.Persona.ObtenerPorId
{
    public class ObtenerPersonaPorIdAD : IObtenerPersonaPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPersonaPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public PersonaTabla Obtener(int id)
        {
            PersonaTabla elInventarioEnBaseDeDatos = _elContexto.PersonaTabla.Where(laPersona => laPersona.IdPersona == id).FirstOrDefault();
            return elInventarioEnBaseDeDatos;
        }
    }
}
