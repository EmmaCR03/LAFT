using LAFT.Abstracciones.AccessoADatos.Interfaces.PalabrasClave.Registrar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.PalabrasClave.Registrar
{
    public class RegistrarPalabraClaveAD : IRegistrarPalabraClaveAD
    {
        Contexto _elContexto;

        public RegistrarPalabraClaveAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Guardar(PalabrasClaveTabla laPalabraClaveAGuardar)
        {
            try
            {
                _elContexto.PalabrasClaveTabla.Add(laPalabraClaveAGuardar);
                EntityState estado = _elContexto.Entry(laPalabraClaveAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}