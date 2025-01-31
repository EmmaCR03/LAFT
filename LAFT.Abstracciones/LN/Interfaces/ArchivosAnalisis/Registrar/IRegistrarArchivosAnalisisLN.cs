using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.Registrar
{
    public interface IRegistrarArchivosAnalisisLN
    {
        Task<int> Guardar(ArchivosAnalisisDTO modelo, string folderPath);
    }
}
