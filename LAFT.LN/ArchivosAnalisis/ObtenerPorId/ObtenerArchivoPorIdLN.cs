using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.ObtenerPorID;
using LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.Persona.ObtenerPorId;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.ArchivosAnalisis.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ArchivosAnalisis.ObtenerPorId
{
    public class ObtenerArchivoPorIdLN : IObtenerArchivosPorIdLN
    {
        IObtenerArchivoPorIdAD _obtenerId;

        public ObtenerArchivoPorIdLN()
        {
            _obtenerId = new ObtenerArchivoPorIdAD();


        }

        public ArchivosAnalisisDTO Obtener(int id)
        {
            ArchivosAnalisisTabla archivoEnBaseDeDatos = _obtenerId.Obtener(id);
            ArchivosAnalisisDTO elArchivoAMostrar = ConvertirAArchivosAMostrar(archivoEnBaseDeDatos);
            return elArchivoAMostrar;
        }

        private ArchivosAnalisisDTO ConvertirAArchivosAMostrar(ArchivosAnalisisTabla archivoEnBaseDeDatos)
        {
            return new ArchivosAnalisisDTO
            {
                IdArchivo = archivoEnBaseDeDatos.IdArchivo,
                Nombre = archivoEnBaseDeDatos.Nombre,
                TextoDelArchivo = archivoEnBaseDeDatos.TextoDelArchivo,
                Fuente = archivoEnBaseDeDatos.Fuente,
                FechaDeRegistro = archivoEnBaseDeDatos.FechaDeRegistro.ToString()

            };

    }

      
    }
}