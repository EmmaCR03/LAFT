using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Conversion;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.General.Conversiones.PalabrasClave
{
    public class ConvertirPalabrasClaveDTOAPalabrasClaveTablaLN : IConvertirPalabrasClaveDTOAPalabrasClaveTablaLN
    {
        IFecha _fecha;

        public ConvertirPalabrasClaveDTOAPalabrasClaveTablaLN()
        {
            _fecha = new Fecha();
        }
        public PalabrasClaveTabla Convertir(PalabrasClaveDTO laPalabra)
        {
            return new PalabrasClaveTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdPalabra = laPalabra.IdPalabra,
                Palabra = laPalabra.Palabra,
                Orden = laPalabra.Orden,
                Estado = laPalabra.Estado
            };
        }
    }
}