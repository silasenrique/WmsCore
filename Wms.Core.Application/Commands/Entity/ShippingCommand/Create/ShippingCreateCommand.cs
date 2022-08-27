using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Entity.Shipping;

namespace Wms.Core.Application.Commands.Entity.ShippingCommand.Create;

public record ShippingCreateCommand(
    string Code,
    string Name,
    string Document,
    int TypeDoc,
    int Status) : ICommand<ErrorOr<ShippingResponse>>;