using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.ObtenerPorId;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using LAFT.AccesoADatos.ActividadesFinancieras.ObtenerPorId;
using LAFT.LN.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesFinancieras.ObtenerPorId
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

        public ActividadesFinancierasDTO Obtener(int id)
        {
            ActividadesFinancierasTabla actividadFEnBaseDeDatos = _obtenerPorIdAD.Obtener(id);
            ActividadesFinancierasDTO laActividadFAMostrar = ConvertirAActividadesFAMostrar(actividadFEnBaseDeDatos);
            return laActividadFAMostrar;
        }

        private ActividadesFinancierasDTO ConvertirAActividadesFAMostrar(ActividadesFinancierasTabla actividadFEnBaseDeDatos)
        {
            return new ActividadesFinancierasDTO
            {
                IdActividadFinanciera = actividadFEnBaseDeDatos.IdActividadFinanciera,
                NombreActividadFinanciera = actividadFEnBaseDeDatos.NombreActividadFinanciera,
                DescripcionActividadFinanciera = actividadFEnBaseDeDatos.DescripcionActividadFinanciera,
                NivelDeRiesgo = actividadFEnBaseDeDatos.NivelDeRiesgo,
                Estado = actividadFEnBaseDeDatos.Estado,
                FechaDeModificacion = actividadFEnBaseDeDatos.ToString(),
                FechaDeRegistro = actividadFEnBaseDeDatos.ToString()
            };
        }

    }
}
