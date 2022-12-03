using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.OwnerUseCases.Command.Delete;

public record DeleteCommand(
    Guid? Id,
    string? Code,
    string? Document,
    bool DeleteDependencies
) : ICommand<Error?>;