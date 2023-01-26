using LojaVirtual.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.API.Data.Mappings
{
    public class ImagemProdutoMapping : IEntityTypeConfiguration<ImagemProduto>
    {
        public void Configure(EntityTypeBuilder<ImagemProduto> builder)
        { 

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            // 1 : N => Marca : produtos
            builder.HasOne(c => c.Produto)
                .WithMany(c => c.Imagens);

            builder.ToTable("imagens_produtos");
        }
    }
}
