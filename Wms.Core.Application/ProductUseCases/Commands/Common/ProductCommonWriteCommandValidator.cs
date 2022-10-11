using FluentValidation;

namespace Wms.Core.Application.ProductUseCases.Commands.Common;

public class ProductCommonWriteCommandValidator : AbstractValidator<ProductCommonWriteCommand>
{
    public ProductCommonWriteCommandValidator()
    {
        RuleFor(p => p.OwnerCode)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("não pode ser nulo")
            .NotEmpty()
            .WithMessage("não pode estar vazio")
            .MaximumLength(20)
            .WithMessage("só aceita até 20 caracteres");

        RuleFor(p => p.Code)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("não pode ser nulo")
            .NotEmpty()
            .WithMessage("não pode estar vazio")
            .MaximumLength(20)
            .WithMessage("só aceita até 20 caracteres");

        RuleFor(p => p.Status)
            .IsInEnum()
            .WithMessage("não é um status válido");

        RuleFor(p => p.Description)
           .MaximumLength(100)
           .WithMessage("excedeu os 100 caracteres permitidos!");
    }
}