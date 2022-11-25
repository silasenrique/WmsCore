using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;

namespace Wms.Core.Application.OwnerUseCases.Command.Create.Commands;

public record OwnerCopyCustomerCommand(
    Guid OwnerBaseId,
    Guid OwnerDestinyId,
    List<Guid> CustomersToBeCopied
) : ICommand<ErrorOr<OwnerResponse>>;