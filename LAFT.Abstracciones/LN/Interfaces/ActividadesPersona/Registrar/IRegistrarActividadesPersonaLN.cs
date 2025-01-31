using LAFT.Abstracciones.Modelos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Registrar
{
    public interface IRegistrarActividadesPersonaLN
    {
        Task<int> Guardar(ActividadesPersonaDTO modelo, string folderPath);
    }
}
