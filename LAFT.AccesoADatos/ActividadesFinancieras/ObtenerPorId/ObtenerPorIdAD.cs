using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.ObtenerPorId;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesFinancieras.ObtenerPorId
{
    public class ObtenerPorIdAD : IObtenerPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public ActividadesFinancierasTabla Obtener(int id)
        {
            ActividadesFinancierasTabla LaActividadFEnBaseDeDatos = _elContexto.ActividadesFinancierasTabla.Where(laActividadF => laActividadF.IdActividadFinanciera == id).FirstOrDefault();
            return LaActividadFEnBaseDeDatos;
        }
    }
}