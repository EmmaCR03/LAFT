using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Listar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.ObtenerPersonaPorId;
using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Listar;
using LAFT.Abstracciones.Modelos.ActividadesPersona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.ActividadesPersona.Listar;
using LAFT.AccesoADatos.ActividadesPersona.ObtenerPersonaPorId;
using LAFT.AccesoADatos.ActividadesPersona.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ActividadesPersona.Listar
{
    public class ListarActividadesPersonaLN : IListarActividadesPersonaLN
    {
        // Interfaz de acceso a datos
        IListarActividadesPersonaAD _listarActividadesPersonaAD;

        public ListarActividadesPersonaLN()
        {
            _listarActividadesPersonaAD = new ListarActividadesPersonaAD();

        }

        public List<ActividadesPersonaDTO> Listar(int idPersona)
        {
            List<ActividadesPersonaDTO> laListaDeActividadesPersona = _listarActividadesPersonaAD.ListarActividadesPersona(idPersona);

            return laListaDeActividadesPersona;
        }

        private List<ActividadesPersonaDTO> ObtenerLaListaConvertida(List<ActividadesPersonaTabla> laListaDeActividadesPersona, List<ActividadesFinancierasTabla> listaDeFinanzas, List<PersonaTabla> listaDePersonas)
        {
            List<ActividadesPersonaDTO> laListaDeActividades = new List<ActividadesPersonaDTO>();


            var joinLista = from laActividadesPersona in laListaDeActividadesPersona
                            join actividadFinanciera in listaDeFinanzas
                            on laActividadesPersona.IdActividadFinanciera equals actividadFinanciera.IdActividadFinanciera
                            join persona in listaDePersonas
                            on laActividadesPersona.IdPersona equals persona.IdPersona
                            select new { laActividadesPersona, actividadFinanciera, persona };

            foreach (var item in joinLista)
            {
                laListaDeActividades.Add(ConvertirObjetoActividadesPersonaDto(item.laActividadesPersona, item.actividadFinanciera, item.persona));
            }

            return laListaDeActividades;
        }


        private ActividadesPersonaDTO ConvertirObjetoActividadesPersonaDto(ActividadesPersonaTabla laActividadesPersona, ActividadesFinancierasTabla actividadFinanciera, PersonaTabla persona)
        {

            return new ActividadesPersonaDTO
            {
                IdActividadPersona = laActividadesPersona.IdActividadPersona,
                IdPersona = persona.IdPersona,
                NombreActividadFinanciera = actividadFinanciera.NombreActividadFinanciera,
                NivelDeRiesgo = actividadFinanciera.NivelDeRiesgo,
                Estado = laActividadesPersona.Estado,
                FechaDeRegistro = laActividadesPersona.FechaDeRegistro.ToString("dd-MM-yyyy hh:mm"),

            };
        }

    }
}

