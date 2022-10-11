using FluentValidation;

namespace Wms.Core.Application.ProviderUseCases.Commands.Common;

public class ProviderCommonWriteCommandValidator : AbstractValidator<ProviderCommonWriteCommand>
{
    public ProviderCommonWriteCommandValidator()
    {
        RuleFor(g => g.Code)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("não pode ser nulo")
            .MaximumLength(20)
            .WithMessage("só é permitido até 20 caracteres");

        RuleFor(g => g.Name)
            .Cascade(CascadeMode.Stop)
            .MaximumLength(100)
            .WithMessage("excedeu os 100 caracteres permitidos!");

        RuleFor(g => g.Document)
            .Cascade(CascadeMode.Stop)
            .Must(doc => doc.Length == 14 || doc.Length == 11)
            .WithMessage("não é um documento valido");

        RuleFor(g => g.TypeDoc)
            .IsInEnum()
            .WithMessage("não é um documento válido");

        RuleFor(g => g.Status)
            .IsInEnum()
            .WithMessage("não é um status válido");
    }
}