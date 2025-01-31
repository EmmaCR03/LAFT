using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Conversiones;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.General.Conversiones.ActividadesFinancieras
{
    public class ConvertirActividadesFinancierasDTOAActividadesFinancierasTablaLN : IConvertirActividadesFinancierasDTOAActividadesFinancierasTablaLN
    { 
        IFecha _fecha;

        public ConvertirActividadesFinancierasDTOAActividadesFinancierasTablaLN()
        {
            _fecha = new Fecha();
        }
        public ActividadesFinancierasTabla Convertir(ActividadesFinancierasDTO laActividadF)
        {
            return new ActividadesFinancierasTabla
            {
                FechaDeRegistro = _fecha.ObtenerFecha(),
                FechaDeModificacion = _fecha.ObtenerFecha(),
                IdActividadFinanciera = laActividadF.IdActividadFinanciera,
                NombreActividadFinanciera = laActividadF.NombreActividadFinanciera,
                DescripcionActividadFinanciera = laActividadF.DescripcionActividadFinanciera,
                NivelDeRiesgo = laActividadF.NivelDeRiesgo,
                Estado = laActividadF.Estado

            };
        }
    }
}