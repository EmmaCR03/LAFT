using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.Listar
{
    public interface IListarArchivosAnalisisAD
    {
        List<ArchivosAnalisisDTO> Listar();
    }
}
