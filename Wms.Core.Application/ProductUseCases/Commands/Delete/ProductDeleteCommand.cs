using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.ProductUseCases.Commands.Delete;

public record ProductDeleteCommand(
    string OwnerCode,
    string Code) : ICommand<Error?>;