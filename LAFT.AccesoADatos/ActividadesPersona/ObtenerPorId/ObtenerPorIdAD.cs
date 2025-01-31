using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.ObtenerPorId;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesPersona.ObtenerPorId
{
    public class ObtenerPorIdAD : IObtenerPorIdAD
        {
            Contexto _elContexto;

    public ObtenerPorIdAD()
    {
        _elContexto = new Contexto();
    }

    public ActividadesPersonaTabla Obtener(int id)
    {
        ActividadesPersonaTabla laActividadPEnBaseDeDatos = _elContexto.ActividadesPersonaTabla.Where(laActividadPersona => laActividadPersona.IdActividadPersona == id).FirstOrDefault();
        return laActividadPEnBaseDeDatos;
    }
}
    }