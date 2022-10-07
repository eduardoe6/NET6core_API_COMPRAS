using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using net6_api_compras.Application.Mappings;
using net6_api_compras.Application.Services;
using net6_api_compras.Application.Services.Interfaces;
using net6_api_compras.Domain.Repositories;
using net6_api_compras.Infra.Data.Context;
using net6_api_compras.Infra.Data.Repositories;

namespace net6_api_compras.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

    }
}
