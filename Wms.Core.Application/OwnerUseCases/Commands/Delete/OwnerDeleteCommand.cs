using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.OwnerUseCases.Commands.Delete;

public record OwnerDeleteCommand(string Code) : ICommand<Error?>;