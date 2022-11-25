using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.CustomerServices.Commands.Create;
using Wms.Core.Application.OwnerUseCases.Contracts;

namespace Wms.Core.Application.OwnerUseCases.Command.Create.Commands;

public record OwnerCreateCommand(
    string Code,
    string Name,
    string Document,
    CreateOrReferACustomerToAnOwner Customers
) : ICommand<ErrorOr<OwnerResponse>>;