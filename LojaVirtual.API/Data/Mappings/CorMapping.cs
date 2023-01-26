using LojaVirtual.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.API.Data.Mappings
{
    public class CorMapping : IEntityTypeConfiguration<Cor>
    {
        public void Configure(EntityTypeBuilder<Cor> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(500)");

            // 1 : N => Marca : produtos
            builder.HasMany(c => c.Produtos)
                .WithOne(c => c.Cor)
                .HasForeignKey(c => c.CorId);

            builder.ToTable("cores");
        }
    }
}
