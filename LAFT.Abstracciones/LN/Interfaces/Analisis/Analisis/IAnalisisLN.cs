using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.LN.Interfaces.Analisis.Registrar
{
    public interface IAnalisisLN
    {
        (string NivelRiesgoGenerado, int TotalDePalabrasClaveEncontradas, int CantidadArchivosEmparejado) Analizar(int idPersona);

    }
}
