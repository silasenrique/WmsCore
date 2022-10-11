using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.OwnerUseCases.Commands.Common;

public record OwnerWriteCommonWriteCommand(
    string Code,
    string Name,
    string Document,
    TypeEntity TypeDoc,
    GlobalStatus Status) : ICommand<ErrorOr<OwnerResponse>>;