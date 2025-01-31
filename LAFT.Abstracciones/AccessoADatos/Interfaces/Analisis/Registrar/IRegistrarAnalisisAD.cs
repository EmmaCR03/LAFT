using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.Registrar
{
    public interface IRegistrarAnalisisAD
    {
        Task<int> Guardar(AnalisisTabla elAnalisisAGuardar);
    }
}
