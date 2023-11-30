using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired();
            builder.Property(p => p.Descricao);
            builder.Property(p => p.Ativo)
            .IsRequired();
        }
    }
}
