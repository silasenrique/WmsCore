using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Delete;

public record ShippingDeleteCommand(string Code) : ICommand<Error?>;