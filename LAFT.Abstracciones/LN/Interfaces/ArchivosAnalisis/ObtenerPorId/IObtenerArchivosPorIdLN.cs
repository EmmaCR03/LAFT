using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.ObtenerPorId
{
    public interface IObtenerArchivosPorIdLN
    {
        ArchivosAnalisisDTO Obtener(int id);
    }
}
