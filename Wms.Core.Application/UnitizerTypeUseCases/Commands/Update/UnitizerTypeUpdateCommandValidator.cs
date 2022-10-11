using FluentValidation;
using Wms.Core.Application.UnitizerTypeUseCases.Commands.Common;

namespace Wms.Core.Application.UnitizerTypeUseCases.Commands.Update;

public class UnitizerTypeUpdateCommandValidator : AbstractValidator<UnitizerTypeUpdateCommand>
{
    public UnitizerTypeUpdateCommandValidator()
    {
        Include(new UnitizerTypeCommonWriteValidator());
    }
}