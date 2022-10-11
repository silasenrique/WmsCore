using FluentValidation;
using Wms.Core.Application.OwnerUseCases.Commands.Common;

namespace Wms.Core.Application.OwnerUseCases.Commands.Create;

public class OwnerCreateCommandValidator : AbstractValidator<OwnerCreateCommand>
{
    public OwnerCreateCommandValidator()
    {
    }
}