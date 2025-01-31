using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Listar;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.Abstracciones.Modelos.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.PalabrasClave.Listar
{
    public class ListarPalabraClaveAD : IListarPalabraClaveAD
    {
        Contexto _elContexto;

        public ListarPalabraClaveAD()
        {
            _elContexto = new Contexto();
        }

        public List<PalabrasClaveDTO> Listar()
        {
            List<PalabrasClaveDTO> laListaDePalabra = (from laPalabra in _elContexto.PalabrasClaveTabla
                                                 select new PalabrasClaveDTO
                                                 {
                                                     FechaDeRegistro = laPalabra.FechaDeRegistro.ToString(),
                                                     FechaDeModificacion = laPalabra.FechaDeModificacion.ToString(),
                                                     IdPalabra = laPalabra.IdPalabra,
                                                     Palabra = laPalabra.Palabra,
                                                     Orden = laPalabra.Orden,
                                                     Estado = laPalabra.Estado

                                                 }

                                                 ).ToList();
            return laListaDePalabra;
        }
    }
}
