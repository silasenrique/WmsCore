using MediatR;
using Wms.Core.Application.Common.Behaviors;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wms.Core.Application.CustomerServices.Services.CreateOwnerCustomerServices;
using Wms.Core.Application.CustomersOwnersServices.Services;
using Wms.Core.Application.OwnerUseCases.Services;

namespace Wms.Core.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<ICustomerServiceCreateOrReferACustomerToAnOwner, CustomerServiceCreateOrReferACustomerToAnOwner>();
        services.AddScoped<ILinkOwnerAndCustomerService, LinkOwnerAndCustomerService>();
        services.AddScoped<ICreateOwnerService, CreateOwnerService>();

        return services;
    }
}