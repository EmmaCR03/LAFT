using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.ObtenerPorId;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using LAFT.AccesoADatos.PalabrasClave.ObtenerPorId;
using LAFT.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.PalabrasClave.ObtenerPorId
{
    public class ObtenerPorIdLN : IObtenerPorIdLN
    {
        IObtenerPorIdAD _obtenerPorIdAD;
        Fecha _fecha;
        public ObtenerPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPorIdAD();
            _fecha = new Fecha();
        }

        public PalabrasClaveDTO Obtener(int id)
        {
            PalabrasClaveTabla palabraEnBaseDeDatos = _obtenerPorIdAD.Obtener(id);
            PalabrasClaveDTO laPalabraAMostrar = ConvertirAPalabraAMostrar(palabraEnBaseDeDatos);
            return laPalabraAMostrar;
        }

        private PalabrasClaveDTO ConvertirAPalabraAMostrar(PalabrasClaveTabla palabraEnBaseDeDatos)
        {
            return new PalabrasClaveDTO
            {
                IdPalabra = palabraEnBaseDeDatos.IdPalabra,
                Orden = palabraEnBaseDeDatos.Orden,
                FechaDeModificacion = palabraEnBaseDeDatos.FechaDeModificacion.ToString(),
                Estado = palabraEnBaseDeDatos.Estado,
                FechaDeRegistro = palabraEnBaseDeDatos.ToString()
            };
        }
    }
}
