using Wms.Core.Application.Abstractions.Entity;
using Wms.Core.Application.Services.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Repository.Entity;

namespace Wms.Core.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<ApplicationContext>();

        // services.AddScoped<IProductService, ProductService>();
        // services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IOwnerService, OwnerService>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();

        return services;
    }
}