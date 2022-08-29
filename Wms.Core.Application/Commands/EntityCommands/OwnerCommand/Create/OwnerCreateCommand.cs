using ErrorOr;
using Wms.Core.Application.Contracts.Entity.Owner;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Create;

public record OwnerCreateCommand(
    string Code,
    string Name,
    string Document,
    int TypeDoc,
    int Status) : ICommand<ErrorOr<OwnerResponse>>;

