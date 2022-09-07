using FluentValidation;
using Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Common;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Update;

public class UnitizerTypeUpdateCommandValidator : AbstractValidator<UnitizerTypeUpdateCommand>
{
    public UnitizerTypeUpdateCommandValidator()
    {
        Include(new UnitizerTypeCommonWriteValidator());
    }
}