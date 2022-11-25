using Microsoft.Extensions.DependencyInjection;
using Wms.Core.Persistence.Common.UnitOfWork;
using Wms.Core.Persistence.CustomerOwnerPersistence.Repository;
using Wms.Core.Persistence.CustomerPersistence.Repository;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

namespace Wms.Core.Persistence.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();

        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerOwnerRepository, CustomerOwnerRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}