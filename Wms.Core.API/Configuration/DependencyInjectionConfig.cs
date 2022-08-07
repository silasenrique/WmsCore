using MediatR;
using Wms.Core.Application.Commands.DistributionCenterCommand;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using Wms.Core.Infrastructure.Repositories.EntityRepository;

namespace Wms.Core.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<ApplicationContext>();

        services.AddScoped<IDistributionCenterRepository, DistributionCenterRepository>();

        services.AddMediatR(typeof(CreateCommand).Assembly);

        return services;
    }
}