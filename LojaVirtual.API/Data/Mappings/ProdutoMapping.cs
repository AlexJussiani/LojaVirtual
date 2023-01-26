using LojaVirtual.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaVirtual.API.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(c => c.ValorDesconto)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.ValorTotal)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.ValorVenda)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

            //1 : N => 1 produto pode conter varias imagens
            builder.HasMany(c => c.Imagens)
                .WithOne(c => c.Produto)
                .HasForeignKey(c => c.ProdutoId);

            builder.HasOne(c => c.Marca)
                .WithMany(c => c.Produtos);

            builder.HasOne(c => c.TipoProduto)
                .WithMany(c => c.Produtos);

            builder.HasOne(c => c.Cor)
               .WithMany(c => c.Produtos);

            builder.ToTable("produtos");
        }
    }
}
