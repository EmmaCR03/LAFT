using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Registrar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesPersona.Registrar
{
    public class RegistrarActividadesPersonaAD : IRegistrarActividadesPersonaAD
    {
        Contexto _elContexto;

        public RegistrarActividadesPersonaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Guardar(ActividadesPersonaTabla laActividadPersonaAGuardar)
        {
            try
            {
                _elContexto.ActividadesPersonaTabla.Add(laActividadPersonaAGuardar);
                EntityState estado = _elContexto.Entry(laActividadPersonaAGuardar).State = System.Data.Entity.EntityState.Added;
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
