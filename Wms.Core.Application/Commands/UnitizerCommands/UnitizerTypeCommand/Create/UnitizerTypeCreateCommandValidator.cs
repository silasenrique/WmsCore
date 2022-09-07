using FluentValidation;
using Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Common;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Create;

public class UnitizerTypeCreateCommandValidator : AbstractValidator<UnitizerTypeCreateCommand>
{
    public UnitizerTypeCreateCommandValidator()
    {
        Include(new UnitizerTypeCommonWriteValidator());
    }
}
