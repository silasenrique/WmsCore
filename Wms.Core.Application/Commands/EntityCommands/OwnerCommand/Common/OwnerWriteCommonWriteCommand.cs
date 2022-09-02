using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Entity.Owner;

namespace Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Common;

public record OwnerWriteCommonWriteCommand
        (string Code,
        string Name,
        string Document,
        int TypeDoc,
        int Status) : ICommand<ErrorOr<OwnerResponse>>;