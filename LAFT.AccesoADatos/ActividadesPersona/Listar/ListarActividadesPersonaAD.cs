using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Listar;
using LAFT.Abstracciones.Modelos.ActividadesPersona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesPersona.Listar
{
    public class ListarActividadesPersonaAD : IListarActividadesPersonaAD
    {
        Contexto _elContexto;

        public ListarActividadesPersonaAD()
        {
            _elContexto = new Contexto();
        }

        public List<ActividadesPersonaDTO> ListarActividadesPersona(int idPersona)
        {

            List<ActividadesPersonaDTO> laListaDeActividadesPersona = (from laActividadesPersona in _elContexto.ActividadesPersonaTabla
                                                                       join actividadFinanciera in _elContexto.ActividadesFinancierasTabla
                                                                       on laActividadesPersona.IdActividadFinanciera equals actividadFinanciera.IdActividadFinanciera
                                                                       join persona in _elContexto.PersonaTabla
                                                                       on laActividadesPersona.IdPersona equals persona.IdPersona

                                                                       where laActividadesPersona.IdPersona == idPersona
                                                                       && laActividadesPersona.Estado == true
                                                                       select new ActividadesPersonaDTO
                                                                       {
                                                                           IdActividadPersona = laActividadesPersona.IdActividadPersona,
                                                                           IdPersona = persona.IdPersona,
                                                                           IdActividadFinanciera = actividadFinanciera.IdActividadFinanciera,
                                                                           NombreActividadFinanciera = actividadFinanciera.NombreActividadFinanciera,
                                                                           NivelDeRiesgo = actividadFinanciera.NivelDeRiesgo,
                                                                           Estado = laActividadesPersona.Estado,
                                                                           FechaDeRegistro = laActividadesPersona.FechaDeRegistro.ToString()
                                                                       }).ToList();

            return laListaDeActividadesPersona;
        }

    }
}