using System.Data.Entity;
using TreinamentoWeb.Dominio.Entidades;

namespace TreinamentoWeb.Infraestrutura.Context
{
    public class TreinamentoWebDbContext : DbContext
    {
        public TreinamentoWebDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasRequired(x => x.Marca)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdMarca)
                .WillCascadeOnDelete(false);
        }
    }
}
