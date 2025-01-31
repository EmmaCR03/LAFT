using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.ObtenerPorId;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.PalabrasClave.ObtenerPorId
{
    public class ObtenerPorIdAD : IObtenerPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public PalabrasClaveTabla Obtener(int id)
        {
            PalabrasClaveTabla laPalabraEnBaseDeDatos = _elContexto.PalabrasClaveTabla.Where(laPalabra=> laPalabra.IdPalabra == id).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}