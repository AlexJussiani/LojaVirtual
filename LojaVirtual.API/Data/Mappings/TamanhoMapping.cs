using LojaVirtual.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.API.Data.Mappings
{
    public class TamanhoMapping : IEntityTypeConfiguration<Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tamanho> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(500)");

            // 1 : N => Marca : produtos
            builder.HasMany(c => c.Produtos)
                .WithOne(c => c.Tamanho)
                .HasForeignKey(c => c.TamanhoId);

            builder.ToTable("tamanhos");
        }
    }
}
