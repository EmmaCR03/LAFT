using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.ObtenerPorID;
using LAFT.Abstracciones.LN.Interfaces.Persona.ObtenerPorId;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ArchivosAnalisis.ObtenerPorId
{
    public class ObtenerArchivoPorIdAD: IObtenerArchivoPorIdAD
    {
        Contexto _elContexto;

        public ObtenerArchivoPorIdAD() 
        { 
        _elContexto = new Contexto();
        }

        public ArchivosAnalisisTabla Obtener(int id)
        {
            ArchivosAnalisisTabla elArchivoEnBaseDeDatos = _elContexto.ArchivosAnalisisTabla.Where(elArchivo => elArchivo.IdArchivo == id).FirstOrDefault();
            return elArchivoEnBaseDeDatos;
        }
    }
}

