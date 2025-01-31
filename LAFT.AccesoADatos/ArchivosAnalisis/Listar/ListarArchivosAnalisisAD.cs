using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.Listar;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ArchivosAnalisis.Listar
{
    public class ListarArchivosAnalisisAD : IListarArchivosAnalisisAD
    {
        Contexto _elContexto;

        public ListarArchivosAnalisisAD() {
            _elContexto = new Contexto();
        }

        public List<ArchivosAnalisisDTO> Listar()
            {
            List<ArchivosAnalisisDTO> laListaDeArchivos = ( from elArchivo in _elContexto.ArchivosAnalisisTabla
                                                 select new ArchivosAnalisisDTO
                                                 {
                                                     FechaDeRegistro = elArchivo.FechaDeRegistro.ToString(),
                                                     Nombre = elArchivo.Nombre,
                                                     TextoDelArchivo = elArchivo.TextoDelArchivo,
                                                     IdArchivo = elArchivo.IdArchivo
                                                 }

                                                ).ToList();
            return laListaDeArchivos;
        }
    }
}


