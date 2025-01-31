using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.Registrar;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.Analisis.Registrar
{
    public class RegistrarAnalisisAD : IRegistrarAnalisisAD
    {
            Contexto _elContexto;

            public RegistrarAnalisisAD()
            {
                _elContexto = new Contexto();
            }
            public async Task<int> Guardar(AnalisisTabla elAnalisisAGuardar)
            {
                try
                {
                    _elContexto.AnalisisTabla.Add(elAnalisisAGuardar);
                    EntityState estado = _elContexto.Entry(elAnalisisAGuardar).State = System.Data.Entity.EntityState.Added;
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
