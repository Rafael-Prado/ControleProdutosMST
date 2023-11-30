using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired();
            builder.Property(p => p.Descricao)
               .IsRequired();
            builder.Property(p => p.Ativo)
               .IsRequired();
            builder.Property(p => p.Perecivel);

        }
    }
}
