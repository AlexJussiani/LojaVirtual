using Ci.Calcados.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ci.Calcados.API.Data.Mappings
{
    public class TipoProdutoMapping : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(EntityTypeBuilder<TipoProduto> builder)
        { 

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            // 1 : N => Marca : produtos
            builder.HasMany(c => c.Produtos)
                .WithOne(c => c.TipoProduto)
                .HasForeignKey(c => c.TipoProdutoId);

            builder.ToTable("tipo_produto");
        }
    }
}
