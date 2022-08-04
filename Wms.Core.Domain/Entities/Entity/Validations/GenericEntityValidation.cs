using FluentValidation;
using Wms.Core.Domain.Entities.Entity.Abstractions;

namespace Wms.Core.Domain.Entities.Entity.Validations;

public class GenericEntityValidation : AbstractValidator<GenericEntity>
{
    public GenericEntityValidation()
    {
        RuleFor(g => g.Status)
            .IsInEnum()
            .WithMessage("{PropertyName} não está no range esperado: 1 = Ativado, 2 = Desativado");

        RuleFor(g => g.TypeDoc)
            .IsInEnum()
            .WithMessage("{PropertyName} não está no range esperado: 1 = LegalPerson, 2 = PhysicalPerson");

        RuleFor(g => g.Code)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado")
            .MaximumLength(20)
            .WithMessage("{PropertyName} só aceita até até 10 caracteres!");

        RuleFor(g => g.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} deve ser informado")
            .MinimumLength(100)
            .WithMessage("{PropertyName} só aceita até 100 caracteres!");

        RuleFor(d => d.Document).NotEmpty().WithMessage("{PropertyName} deve ser informado!");

        // TODO: adicionar uma custom validation validando o documento: CNPJ e CPF
    }
}