using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Editar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.PalabrasClave.Editar
{
    public class EditarPalabrasClaveAD : IEditarPalabrasClaveAD
    {
        Contexto _elContexto;

        public EditarPalabrasClaveAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(PalabrasClaveTabla laPalabraActualizar)
        {
            PalabrasClaveTabla laPalabraEnBaseDeDatos = _elContexto.PalabrasClaveTabla.Where(laPalabra => laPalabra.IdPalabra == laPalabraActualizar.IdPalabra).FirstOrDefault();
            laPalabraEnBaseDeDatos.Palabra = laPalabraActualizar.Palabra;
            laPalabraEnBaseDeDatos.Orden = laPalabraActualizar.Orden;
            laPalabraEnBaseDeDatos.FechaDeRegistro = laPalabraActualizar.FechaDeRegistro;
            laPalabraEnBaseDeDatos.FechaDeModificacion = laPalabraActualizar.FechaDeModificacion;
            laPalabraEnBaseDeDatos.Estado = laPalabraActualizar.Estado;
            EntityState estado = _elContexto.Entry(laPalabraEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}