using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Eliminar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Eliminar;
using LAFT.AccesoADatos.ActividadesPersona.Eliminar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesPersona.Eliminar
{
    public class EliminarActividadesPersonaLN : IEliminarActividadesPersonaLN
    {
        IEliminarActividadesPersonaAD _eliminarActividadesPersonaAD;

        public EliminarActividadesPersonaLN()
        { 
            _eliminarActividadesPersonaAD = new EliminarActividadesPersonaAD();
        }

        public async Task<int> Eliminar(int IdActividadPersona)
        {
            int cantidadDeDatosEliminados = await _eliminarActividadesPersonaAD.Eliminar(IdActividadPersona);
            return cantidadDeDatosEliminados;
        }
    }
}