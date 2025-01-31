using LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos;
using LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos.Bitacora.Listar;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.BitacoraEventos.Listar
{
    public class ListarBitacoraEventosAD : IListarBitacoraEventosAD
    {
        Contexto _elContexto;


        // Constructor
        public ListarBitacoraEventosAD()
        {
            _elContexto = new Contexto();
        }

        public List<BitacoraEventosDTO> Listar()
        {
            var laListaDeBitacoras = (from laBitacora in _elContexto.BitacoraEventosTabla
                                      select new BitacoraEventosDTO
                                      {
                                          IdEvento = laBitacora.IdEvento,
                                          TablaDeEvento = laBitacora.TablaDeEvento,
                                          TipoDeEvento = laBitacora.TipoDeEvento,
                                          FechaDeEvento = laBitacora.FechaDeEvento.ToString(), 
                                          DescripcionDeEvento = laBitacora.DescripcionDeEvento,
                                          StackTrace = laBitacora.StackTrace,
                                          DatosAnteriores = laBitacora.DatosAnteriores,
                                          DatosPosteriores = laBitacora.DatosPosteriores
                                      }).ToList();

            return laListaDeBitacoras;
        }

    }
}

