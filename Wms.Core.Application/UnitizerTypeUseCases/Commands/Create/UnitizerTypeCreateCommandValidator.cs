using FluentValidation;
using Wms.Core.Application.UnitizerTypeUseCases.Commands.Common;

namespace Wms.Core.Application.UnitizerTypeUseCases.Commands.Create;

public class UnitizerTypeCreateCommandValidator : AbstractValidator<UnitizerTypeCreateCommand>
{
    public UnitizerTypeCreateCommandValidator()
    {
        Include(new UnitizerTypeCommonWriteValidator());
    }
}
