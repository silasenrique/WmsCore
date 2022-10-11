using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.UnitizerTypeUseCases.Commands.Delete;

public record UnitizerTypeDeleteCommand(string Code) : ICommand<Error?>;