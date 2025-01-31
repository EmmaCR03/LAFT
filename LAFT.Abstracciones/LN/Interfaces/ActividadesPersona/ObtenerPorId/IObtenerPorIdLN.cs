using LAFT.Abstracciones.Modelos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.ObtenerPorId
{
    public interface IObtenerPorIdLN
    {
        ActividadesPersonaDTO Obtener(int IdActividadPersona);
    }
}
