using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.ObtenerPersonaPorId;

namespace LAFT.AccesoADatos.ActividadesPersona.ObtenerPersonaPorId
{
    public class ObtenerPersonaPorIdAD : IObtenerPersonaPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPersonaPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public ActividadesPersonaTabla ObtenerPersonaPorId(int idActividadPersona)
        {
            return _elContexto.ActividadesPersonaTabla
                .FirstOrDefault(a => a.IdPersona == idActividadPersona);
        }
    }
}
