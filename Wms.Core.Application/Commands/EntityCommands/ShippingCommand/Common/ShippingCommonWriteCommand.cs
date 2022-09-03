using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.Shipping;

namespace Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Common;

public record ShippingCommonWriteCommand(
    string Code,
    string Name,
    string Document,
    int TypeDoc,
    int Status) : ICommand<ErrorOr<ShippingResponse>>;