using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.ObtenerPorID
{
    public interface IObtenerArchivoPorIdAD
    {
        ArchivosAnalisisTabla Obtener(int id);
    }
}
