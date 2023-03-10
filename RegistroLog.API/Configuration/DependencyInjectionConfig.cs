using Microsoft.Extensions.DependencyInjection;
using RegistroLog.API.Data.Repository;

namespace RegistroLog.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventoRepository, EventoRepository>();
        }
    }
}
