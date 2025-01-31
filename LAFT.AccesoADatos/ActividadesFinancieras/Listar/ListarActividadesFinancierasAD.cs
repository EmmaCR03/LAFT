using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesFinancieras.Listar
{
    public class ListarActividadesFinancierasAD : IListarActividadesFinancierasAD
    {
        Contexto _elContexto;

        public ListarActividadesFinancierasAD()
        {
            _elContexto = new Contexto();
        }

        public List<ActividadesFinancierasDTO> Listar()
        {
            List<ActividadesFinancierasDTO> laListaDeActividadesF = (from laActividadF in _elContexto.ActividadesFinancierasTabla
                                                                     select new ActividadesFinancierasDTO
                                                                     {
                                                                         IdActividadFinanciera = laActividadF.IdActividadFinanciera,
                                                                         NombreActividadFinanciera = laActividadF.NombreActividadFinanciera,
                                                                         DescripcionActividadFinanciera = laActividadF.DescripcionActividadFinanciera,
                                                                         NivelDeRiesgo = laActividadF.NivelDeRiesgo,
                                                                         FechaDeRegistro = laActividadF.FechaDeRegistro.ToString(),
                                                                         FechaDeModificacion = laActividadF.FechaDeModificacion.ToString(),
                                                                         Estado = laActividadF.Estado
                                                                     }

                                                 ).ToList();
            return laListaDeActividadesF;
        }
    }
}


