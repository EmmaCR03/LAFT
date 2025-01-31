using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.Abstracciones.Modelos.ActividadesPersona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Listar
{
    public interface IListarActividadesPersonaAD
    {
        List<ActividadesPersonaDTO> ListarActividadesPersona(int idPersona);

    }
}
