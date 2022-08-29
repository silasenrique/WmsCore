using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Delete;

public record OwnerDeleteCommand(string Code) : ICommand<Error?>;