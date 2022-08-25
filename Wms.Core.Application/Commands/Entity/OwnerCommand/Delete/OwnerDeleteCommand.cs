using ErrorOr;
using Wms.Core.Application.Abstractions.Messaging;

namespace Wms.Core.Application.Commands.Entity.OwnerCommand.Delete
{
    public record OwnerDeleteCommand(string Code) : ICommand<Error?>;
}