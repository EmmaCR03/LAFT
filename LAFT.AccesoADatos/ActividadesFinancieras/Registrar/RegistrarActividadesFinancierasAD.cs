using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.Registrar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesFinancieras.Registrar
{
    public class RegistrarActividadesFinancierasAD : IRegistrarActividadesFinancierasAD
    {
        Contexto _elContexto;

        public RegistrarActividadesFinancierasAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Guardar(ActividadesFinancierasTabla laActividadAGuardarF)
        {
            try
            {
                _elContexto.ActividadesFinancierasTabla.Add(laActividadAGuardarF);
                EntityState estado = _elContexto.Entry(laActividadAGuardarF).State = System.Data.Entity.EntityState.Added;
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