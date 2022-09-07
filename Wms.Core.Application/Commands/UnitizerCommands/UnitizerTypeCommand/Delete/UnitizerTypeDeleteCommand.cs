using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Delete;

public record UnitizerTypeDeleteCommand(string Code) : ICommand<Error?>;