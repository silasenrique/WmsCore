using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Delete;

public record ProductDeleteCommand(
    string OwnerCode,
    string Code) : ICommand<Error?>;