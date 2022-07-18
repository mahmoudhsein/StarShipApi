using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace StarShip
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServicess(this IServiceCollection services)
        {
            services.AddTransient<IHttpClientAdapter, HttpClientAdapter>();
            services.AddTransient<IStartShipService, StartShipService>();
        }
    }
}
