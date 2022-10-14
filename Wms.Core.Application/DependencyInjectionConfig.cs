using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Wms.Core.Application.Common.Behaviors;
using Wms.Core.Application.DistributionCenterUseCases.Services.Create;
using Wms.Core.Application.DistributionCenterUseCases.Services.Update;

namespace Wms.Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IDistributionCenterUpdateService, DistributionCenterUpdateService>();
        services.AddScoped<IDistributionCenterCreateService, DistributionCenterCreateService>();

        return services;
    }
}