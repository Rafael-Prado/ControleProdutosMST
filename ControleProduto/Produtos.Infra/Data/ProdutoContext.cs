
using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(){}
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost,1433;Initial Catalog=PRODUTOSTORE;User Id=sa;Password=131823Wotoro@;Trusted_Connection=false;");
            }
        }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Nome).IsRequired();
                e.Property(p => p.Descricao).IsRequired();
                e.Property(p => p.Ativo).IsRequired();
                e.Property(p => p.Perecivel);

            });

            modelBuilder.Entity<CategoriaProduto>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(p => p.Nome).IsRequired();
                e.Property(p => p.Descricao);
                e.Property(p => p.Ativo).IsRequired();

                e.HasMany(c => c.Produtos)
                    .WithOne()
                    .HasForeignKey(s => s.CategoriaId);

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
