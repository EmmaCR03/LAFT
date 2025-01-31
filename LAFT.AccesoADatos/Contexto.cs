
﻿using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesFinancieras;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ActividadesPersona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Analisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.ArchivosAnalisis;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.PalabrasClave;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;
﻿using LAFT.Abstracciones.ModelosDeBaseDeDatos.Persona.Persona;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.AccesoADatos
{
    public class Contexto: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonaTabla>().ToTable("Persona");
            modelBuilder.Entity<ArchivosAnalisisTabla>().ToTable("Archivos_Analisis");
            modelBuilder.Entity<BitacoraEventosTabla>().ToTable("Bitacora_Eventos");
            modelBuilder.Entity<ActividadesPersonaTabla>().ToTable("Actividad_Persona");
            modelBuilder.Entity<ActividadesFinancierasTabla>().ToTable("Actividad_Financiera");
            modelBuilder.Entity<PalabrasClaveTabla>().ToTable("PalabrasClave");
            modelBuilder.Entity<AnalisisTabla>().ToTable("Analisis");



        }
        public DbSet<PersonaTabla> PersonaTabla { get; set; }
        public DbSet<ArchivosAnalisisTabla> ArchivosAnalisisTabla { get; set; }
        public DbSet<BitacoraEventosTabla> BitacoraEventosTabla { get; set; }
        public DbSet<ActividadesPersonaTabla> ActividadesPersonaTabla { get; set; }
        public DbSet<ActividadesFinancierasTabla> ActividadesFinancierasTabla { get; set; }
        public DbSet<PalabrasClaveTabla> PalabrasClaveTabla { get; set; }
        public DbSet<AnalisisTabla> AnalisisTabla { get; set; }





    }
}
