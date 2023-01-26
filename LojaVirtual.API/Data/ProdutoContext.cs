using Ci.Calcados.API.Models;
using Ci.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ci.Calcados.API.Data
{
    public class ProdutoContext : DbContext, IUnitOfWork
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ImagemProduto> ImagemProduto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Tamanho> Tamanho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries()
                 .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;
           // if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}
