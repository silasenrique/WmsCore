using FluentValidation;
using Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Create;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand;

public class DistributionCenterCreateCommandValidation : AbstractValidator<DistributionCenterCreateCommand>
{
    public DistributionCenterCreateCommandValidation()
    {
        RuleFor(d => d.Code)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado!");

        RuleFor(d => d.Code)
            .MaximumLength(10)
            .WithMessage("{PropertyName} só aceita até até 10 caracteres!");

        RuleFor(d => d.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado!")
            .MaximumLength(100)
            .WithMessage("{PropertyName} só aceita até 100 caracteres!");

        RuleFor(d => d.Document).NotEmpty().WithMessage("{PropertyName} deve ser informado!");

        // TODO: adicionar uma custom validation validando o documento: CNPJ e CPF
    }
}