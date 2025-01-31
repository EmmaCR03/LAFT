using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Listar;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using LAFT.AccesoADatos.ActividadesFinancieras.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesFinancieras.Listar
{
    public class ListarActividadesFinancierasLN : IListarActividadesFinancierasLN
    {
        IListarActividadesFinancierasAD _listarActividadesFinancierasAD;
        public ListarActividadesFinancierasLN()
        {
            _listarActividadesFinancierasAD = new ListarActividadesFinancierasAD();

        }

        public List<ActividadesFinancierasDTO> ListarActividad()
        {
            List<ActividadesFinancierasDTO> laListaDeActividadesF = _listarActividadesFinancierasAD.Listar();
            return laListaDeActividadesF;
        }

        private List<ActividadesFinancierasDTO> ObtenerLaListaConvertida(List<ActividadesFinancierasTabla> laListaDeActividadesF)
        {
            List<ActividadesFinancierasDTO> laListaDeActividadesFin = new List<ActividadesFinancierasDTO>();
            foreach (ActividadesFinancierasTabla laActividadF in laListaDeActividadesF)
            {
                laListaDeActividadesFin.Add(ConvertirObjetoActividadesFinancierasDto(laActividadF));
            }
            return laListaDeActividadesFin;
        }


        private ActividadesFinancierasDTO ConvertirObjetoActividadesFinancierasDto(ActividadesFinancierasTabla laActividadF)
        {
            return new ActividadesFinancierasDTO
            {
                FechaDeRegistro = laActividadF.FechaDeRegistro.ToString("dd-MM-yyyy hh:mm tt"),
                FechaDeModificacion = laActividadF.FechaDeModificacion.ToString("dd-MM-yyyy hh:mm tt"),
                IdActividadFinanciera = laActividadF.IdActividadFinanciera,
                NombreActividadFinanciera = laActividadF.NombreActividadFinanciera,
                DescripcionActividadFinanciera = laActividadF.DescripcionActividadFinanciera,
                NivelDeRiesgo = laActividadF.NivelDeRiesgo,
                Estado = laActividadF.Estado

            };
        }
    }
}

