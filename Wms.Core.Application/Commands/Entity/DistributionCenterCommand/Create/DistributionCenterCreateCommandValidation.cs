using FluentValidation;
using Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Create;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand;

public class DistributionCenterCreateCommandValidation : AbstractValidator<DistributionCenterCreateCommand>
{
    public DistributionCenterCreateCommandValidation()
    {
        RuleFor(d => d.Code).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} deve ser informado!")
            .MaximumLength(10).WithMessage("{PropertyName} só aceita até até 10 caracteres!");

        RuleFor(d => d.Name).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} deve ser informado!")
            .MaximumLength(100).WithMessage("{PropertyName} só aceita até 100 caracteres!");

        RuleFor(d => d.Document).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("{PropertyName} deve ser informado!")
            .Must(doc => doc.Length == 11 || doc.Length == 14).WithMessage("{PropertyName} não é um documento válido!");
        // TODO: adicionar uma custom validation validando o documento: CNPJ e CPF
    }
}