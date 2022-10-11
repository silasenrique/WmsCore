using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.ProviderUseCases.Commands.Delete;

public record ProviderDeleteCommand(string Code) : ICommand<Error?>;