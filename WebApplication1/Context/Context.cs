using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
namespace WebApplication1.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CSApoo")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<ConsultaExame> ConsultaExames { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}