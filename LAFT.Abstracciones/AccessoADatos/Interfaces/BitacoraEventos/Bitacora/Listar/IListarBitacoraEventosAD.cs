﻿using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos.Bitacora.Listar
{
    public interface IListarBitacoraEventosAD
    {
        List<BitacoraEventosDTO> Listar();
    }
}
