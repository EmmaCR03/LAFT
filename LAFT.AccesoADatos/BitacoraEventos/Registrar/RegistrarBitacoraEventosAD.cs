using LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos.Bitacora;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.BitacoraEventos.Registrar
{
    public class RegistrarBitacoraEventosAD : IRegistrarBitacoraServiceAD
    {
        Contexto _context;

        public RegistrarBitacoraEventosAD()
        {
            _context = new Contexto();
        }

        public async Task<int> RegistrarEvento(BitacoraEventosTabla evento)
        {
            // Mapeo de BitacoraDTO a BitacoraEventosTabla
            try
            {
                _context.BitacoraEventosTabla.Add(evento);
                int cantidadDeDatosAlmacenados = await _context.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}