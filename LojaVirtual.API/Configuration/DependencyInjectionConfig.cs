using LojaVirtual.API.Data;
using LojaVirtual.API.Data.Repository;
using LojaVirtual.API.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ProdutoContext>();
            services.AddScoped<IProdutoService, ProdutoServices>();
        }
    }
}