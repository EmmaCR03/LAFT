using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesFinancieras.Editar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.ActividadesFinancieras.Editar
{
    public class EditarActividadesFinancierasAD : IEditarActividadesFinancierasAD
    {
        Contexto _elContexto;

        public EditarActividadesFinancierasAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Editar(ActividadesFinancierasTabla laActividadFActualizar)
        {
            ActividadesFinancierasTabla laActividadFEnBaseDeDatos = _elContexto.ActividadesFinancierasTabla.Where(laActividadF => laActividadF.IdActividadFinanciera == laActividadFActualizar.IdActividadFinanciera).FirstOrDefault();
            laActividadFEnBaseDeDatos.NombreActividadFinanciera = laActividadFActualizar.NombreActividadFinanciera;
            laActividadFEnBaseDeDatos.DescripcionActividadFinanciera = laActividadFActualizar.DescripcionActividadFinanciera;
            laActividadFEnBaseDeDatos.NivelDeRiesgo = laActividadFActualizar.NivelDeRiesgo;
            laActividadFEnBaseDeDatos.FechaDeRegistro = laActividadFActualizar.FechaDeRegistro;
            laActividadFEnBaseDeDatos.FechaDeModificacion = laActividadFActualizar.FechaDeModificacion;
            laActividadFEnBaseDeDatos.Estado = laActividadFActualizar.Estado;
            EntityState estado = _elContexto.Entry(laActividadFEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}