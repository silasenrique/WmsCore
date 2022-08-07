using MediatR;
using Wms.Core.Application.Commands.Entity.DistributionCenter.Common;
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

        services.AddMediatR(typeof(DistributionCenterWriteCommand).Assembly);

        return services;
    }
}