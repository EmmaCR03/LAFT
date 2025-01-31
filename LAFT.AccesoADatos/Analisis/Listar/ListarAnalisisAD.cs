﻿using LAFT.Abstracciones.AccessoADatos.Interfaces.Analisis.Listar;
using LAFT.Abstracciones.Modelos.Analisis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos.Analisis.Listar
{
    public class ListarAnalisisAD: IListarAnalisisAD
    {
        Contexto _elContexto;

        public ListarAnalisisAD()
        {
            _elContexto = new Contexto();
        }

        public List<PersonaAnalizadaDto> Listar()
        {
            List<PersonaAnalizadaDto> lalistadeAnalisis = (from laPersona in _elContexto.PersonaTabla
                                                           join elAnalisis in _elContexto.AnalisisTabla
                                                           on laPersona.IdPersona equals elAnalisis.IdPersona
                                                           into Juntar
                                                           where Juntar.Any()
                                                           select new PersonaAnalizadaDto
                                                           {
                                                               IdPersona = laPersona.IdPersona,
                                                               TipoIdentificacion = laPersona.TipoIdentificacion,
                                                               NombrePersona = laPersona.NombrePersona,
                                                               PrimerApellidoPersona = laPersona.PrimerApellidoPersona,
                                                               SegundoApellidoPersona = laPersona.SegundoApellidoPersona,
                                                               NivelDeRiesgoGenerado = laPersona.EstadoDeRiesgo,
                                                               FechaDeAnalisis = Juntar.Max(a => a.FechaDeAnalisis)
                                                           }).ToList();
            return lalistadeAnalisis;

        }
    }
}

