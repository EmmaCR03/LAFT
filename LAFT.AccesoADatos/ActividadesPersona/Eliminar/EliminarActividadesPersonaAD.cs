using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Eliminar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesPersona.Eliminar
{
    public class EliminarActividadesPersonaAD : IEliminarActividadesPersonaAD
    {
        Contexto _elContexto;

        public EliminarActividadesPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(int IdActividadPersona)
        {
            ActividadesPersonaTabla laActividadP = _elContexto.ActividadesPersonaTabla.Where(laActividad => laActividad.IdActividadPersona == IdActividadPersona).FirstOrDefault();
            _elContexto.ActividadesPersonaTabla.Remove(laActividadP);
            EntityState estado = _elContexto.Entry(laActividadP).State = System.Data.Entity.EntityState.Deleted;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}