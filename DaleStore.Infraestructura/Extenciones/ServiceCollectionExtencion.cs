using DaleStore.Core.Interfaces;
using DaleStore.Core.Interfaces.Servicios;
using DaleStore.Core.Servicios;
using DaleStore.Infraestructura.Data;
using DaleStore.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DaleStore.Infraestructura.Extenciones
{
    public static class ServiceCollectionExtencion
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DaleStoreContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DaleStore"),
               sqlServerOptionsAction: SqlServerDbContextOptionsExtensions => 
               {
                   SqlServerDbContextOptionsExtensions.EnableRetryOnFailure(); 
               })
           );
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            
            services.AddScoped<IClienteServicio, ClienteServicio>();
            services.AddScoped<IProductoServicio, ProductoServicio>();
            services.AddScoped<IVentaServicio, VentaServicio>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }


    }
}
