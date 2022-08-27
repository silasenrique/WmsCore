using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Entity.Shipping;

namespace Wms.Core.Application.Commands.Entity.ShippingCommand.Update;

public record ShippingUpdateCommand(
    int Id,
    string Code,
    string Name,
    string Document,
    int TypeDoc,
    int Status) : ICommand<ErrorOr<ShippingResponse>>;