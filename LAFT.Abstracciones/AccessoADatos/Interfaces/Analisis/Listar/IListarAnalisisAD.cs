using LAFT.Abstracciones.Modelos.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.Listar
{
    public interface IListarAnalisisAD
    {
        List<PersonaAnalizadaDto> Listar();
    }
}
