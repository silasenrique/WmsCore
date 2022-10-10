using FluentValidation;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Common;

public class DistributionCenterCommonWriteCommandValidator : AbstractValidator<DistributionCenterCommonWriteCommand>
{
    public DistributionCenterCommonWriteCommandValidator()
    {
        RuleFor(d => d.Code).Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage("deve ser informado!")
           .MaximumLength(10).WithMessage("só aceita até até 10 caracteres!");

        RuleFor(d => d.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} deve ser informado!")
            .MaximumLength(100).WithMessage("{PropertyName} só aceita até 100 caracteres!");

        RuleFor(d => d.Document).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} deve ser informado!")
            .Must(doc => doc.Length == 11 || doc.Length == 14).WithMessage("{PropertyName} não é um documento válido!");
    }
}