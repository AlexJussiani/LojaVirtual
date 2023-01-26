using Ci.Calcados.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ci.Calcados.API.Data.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        { 

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            // 1 : N => Marca : produtos
            builder.HasMany(c => c.Produtos)
                .WithOne(c => c.Marca)
                .HasForeignKey(c => c.MarcaId);

            builder.ToTable("marcas");
        }
    }
}
