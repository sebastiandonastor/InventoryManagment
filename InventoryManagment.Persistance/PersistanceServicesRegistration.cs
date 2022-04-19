using InventoryManagment.Application.Contracts.Persistence;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagment.Persistance
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryManagmentDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("InventoryManagmentConnectionString")));

            #region Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            #endregion

            #region Caching
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
            });
            #endregion
            return services;
        }
    }
}
