using LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos;
using LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos.Bitacora.Listar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Listar;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using LAFT.AccesoADatos.BitacoraEventos.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.BitacoraEventos
{
    public class ListarBitacoraEventosLN: IListarBitacoraEventosLN
    {
        IListarBitacoraEventosAD _listarBitacoraEventosAD;

        public ListarBitacoraEventosLN() 
        {
            _listarBitacoraEventosAD = new ListarBitacoraEventosAD();
        }

        public List<BitacoraEventosDTO> ListarBitacora()
        {
            List<BitacoraEventosDTO> laListasDeBitacora = _listarBitacoraEventosAD.Listar();
            return laListasDeBitacora;
        }
        private List<BitacoraEventosDTO> ObtenerLaListaConvertida(List<BitacoraEventosTabla> laListasDeBitacoras)
        {
            List<BitacoraEventosDTO> laListaDeBitacoras = new List<BitacoraEventosDTO>();
            foreach (BitacoraEventosTabla laBitacora in laListasDeBitacoras)
            {
                laListaDeBitacoras.Add(ConvertirObjetoDTO(laBitacora));
            }
            return laListaDeBitacoras;
        }
        private BitacoraEventosDTO ConvertirObjetoDTO(BitacoraEventosTabla laBitacora)
        {

            return new BitacoraEventosDTO
            {
                IdEvento = laBitacora.IdEvento,
                TablaDeEvento = laBitacora.TablaDeEvento,
                TipoDeEvento = laBitacora.TipoDeEvento,
                FechaDeEvento = laBitacora.FechaDeEvento.ToString("dd-MM-yyyy hh:mm tt"),
                DescripcionDeEvento = laBitacora.DescripcionDeEvento,
                StackTrace = laBitacora.StackTrace,
                DatosAnteriores = laBitacora.DatosAnteriores,
                DatosPosteriores = laBitacora.DatosPosteriores

            };
        }
    }
}
