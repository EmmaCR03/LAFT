using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.ObtenerPorId;
using LAFT.Abstracciones.Modelos.ActividadesPersona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using LAFT.AccesoADatos.ActividadesPersona.ObtenerPorId;
using LAFT.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesPersona.ObtenerPorId
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

        public ActividadesPersonaDTO Obtener(int IdActividadPersona)
        {
            ActividadesPersonaTabla actividadPersonaEnBaseDeDatos = _obtenerPorIdAD.Obtener(IdActividadPersona);
            ActividadesPersonaDTO laActividadPersonaAMostrar = ConvertirActividadesPersonaAMostrar(actividadPersonaEnBaseDeDatos);
            return laActividadPersonaAMostrar;
        }

        private ActividadesPersonaDTO ConvertirActividadesPersonaAMostrar(ActividadesPersonaTabla actividadPersonaEnBaseDeDatos)
        {
            return new ActividadesPersonaDTO
            {
                IdActividadPersona = actividadPersonaEnBaseDeDatos.IdActividadPersona,
                IdActividadFinanciera = actividadPersonaEnBaseDeDatos.IdActividadFinanciera,
                IdPersona = actividadPersonaEnBaseDeDatos.IdPersona,
                Estado = actividadPersonaEnBaseDeDatos.Estado,
                FechaDeRegistro = actividadPersonaEnBaseDeDatos.ToString(),
                FechaDeModificacion = actividadPersonaEnBaseDeDatos.ToString()
            };
        }

    }
}
