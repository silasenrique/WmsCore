using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Wms.Core.Application.Common.Mapping;

namespace Wms.Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddMappings();
        return services;
    }
}