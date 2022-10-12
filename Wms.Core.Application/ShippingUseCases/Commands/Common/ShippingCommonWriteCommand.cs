using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ShippingUseCases.Contracts;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ShippingUseCases.Commands.Common;

public record ShippingCommonWriteCommand(
    string Code,
    string Name,
    string Document,
    TypeEntity TypeDoc,
    GlobalStatus Status) : ICommand<ErrorOr<ShippingResponse>>;