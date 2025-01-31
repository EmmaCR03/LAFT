using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Registrar
{
    public interface IRegistrarActividadesFinancierasLN
    {
        Task<int> Guardar(ActividadesFinancierasDTO modelo, string folderPath);
    }
}
