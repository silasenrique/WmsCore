using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Delete;

public record ProviderDeleteCommand(string Code) : ICommand<Error?>;