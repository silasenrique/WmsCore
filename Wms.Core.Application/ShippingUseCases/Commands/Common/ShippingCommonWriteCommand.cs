using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ShippingUseCases.Contracts;

namespace Wms.Core.Application.ShippingUseCases.Commands.Common;

public record ShippingCommonWriteCommand(
    string Code,
    string Name,
    string Document,
    int TypeDoc,
    int Status) : ICommand<ErrorOr<ShippingResponse>>;