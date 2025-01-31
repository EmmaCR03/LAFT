using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.Listar;
using LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.Listar;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using LAFT.AccesoADatos.ArchivosAnalisis.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.ArchivosAnalisis.Listar
{
    public class ListarArchivosAnalisisLN : IListarArchivosAnalisisLN
    {
        IListarArchivosAnalisisAD _listarArchivosAnalisisAD;

        public ListarArchivosAnalisisLN()
        {
            _listarArchivosAnalisisAD = new ListarArchivosAnalisisAD();
        }

        public List<ArchivosAnalisisDTO> Listar()
        {
            List<ArchivosAnalisisDTO> laListaDeArchivo = _listarArchivosAnalisisAD.Listar();
            return laListaDeArchivo;
        }

       
        }
    }
