﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC1117.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class hospitalEntities : DbContext
    {
        public hospitalEntities()
            : base("name=hospitalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cita> cita { get; set; }
        public virtual DbSet<medico> medico { get; set; }
        public virtual DbSet<paciente> paciente { get; set; }
    
        public virtual int actualizar_cita(string cod_cita, Nullable<System.DateTime> fecha, Nullable<System.TimeSpan> hora, string id_paciente, string id_medico, Nullable<int> valor, string diagnostico, string nom_acompañante, Nullable<bool> activo)
        {
            var cod_citaParameter = cod_cita != null ?
                new ObjectParameter("cod_cita", cod_cita) :
                new ObjectParameter("cod_cita", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var horaParameter = hora.HasValue ?
                new ObjectParameter("hora", hora) :
                new ObjectParameter("hora", typeof(System.TimeSpan));
    
            var id_pacienteParameter = id_paciente != null ?
                new ObjectParameter("id_paciente", id_paciente) :
                new ObjectParameter("id_paciente", typeof(string));
    
            var id_medicoParameter = id_medico != null ?
                new ObjectParameter("id_medico", id_medico) :
                new ObjectParameter("id_medico", typeof(string));
    
            var valorParameter = valor.HasValue ?
                new ObjectParameter("valor", valor) :
                new ObjectParameter("valor", typeof(int));
    
            var diagnosticoParameter = diagnostico != null ?
                new ObjectParameter("diagnostico", diagnostico) :
                new ObjectParameter("diagnostico", typeof(string));
    
            var nom_acompañanteParameter = nom_acompañante != null ?
                new ObjectParameter("nom_acompañante", nom_acompañante) :
                new ObjectParameter("nom_acompañante", typeof(string));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("actualizar_cita", cod_citaParameter, fechaParameter, horaParameter, id_pacienteParameter, id_medicoParameter, valorParameter, diagnosticoParameter, nom_acompañanteParameter, activoParameter);
        }
    }
}