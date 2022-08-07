using Microsoft.Extensions.DependencyInjection;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using Wms.Core.Infrastructure.Repositories.EntityRepository;

namespace Wms.Core.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationContext>();
        services.AddScoped<IDistributionCenterRepository, DistributionCenterRepository>();

        return services;
    }
}