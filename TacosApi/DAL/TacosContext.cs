using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TacosApi.Models;

namespace TacosApi.DAL
{
    public class TacosContext : DbContext
    {

        public TacosContext(): base("TacosConnection")
        {
            Database.SetInitializer<TacosContext>(null);
        }

        public DbSet<TipoTaco> TiposDeTaco { get; set; }
        public DbSet<Pais> Paises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<TipoTaco>().HasKey(c => c.id);
            modelBuilder.Entity<TipoTaco>().ToTable("TipoTaco", schemaName: "dbo");
            modelBuilder.Entity<Pais>().HasKey(c => c.PaisID);
            modelBuilder.Entity<Pais>().ToTable("pais", schemaName: "sepomex");
        }
    }
}