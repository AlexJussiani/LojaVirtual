using Ci.Calcados.API.Data;
using Ci.Calcados.API.Data.Repository;
using Ci.Calcados.API.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ci.Calcados.API.Configuration
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