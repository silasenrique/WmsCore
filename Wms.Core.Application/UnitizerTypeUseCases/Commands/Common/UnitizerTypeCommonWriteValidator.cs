using FluentValidation;

namespace Wms.Core.Application.UnitizerTypeUseCases.Commands.Common;

public class UnitizerTypeCommonWriteValidator : AbstractValidator<UnitizerTypeCommonWriteCommand>
{
    public UnitizerTypeCommonWriteValidator()
    {
        RuleFor(u => u.Code)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("não pode ser nulo ou vazio");

        RuleFor(u => u.Description)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(10)
            .WithMessage("é necessário informar uma descrição com no mínimo 10 caracteres")
            .MaximumLength(100)
            .WithMessage("excedeu a capacidade máxima, só aceita até 100 caracteres");

        // RuleFor(u => new { u.MaximumWeight, u.WeightUnit })
        //     .Cascade(CascadeMode.Stop)
        //     .Must(u => u.WeightUnit == 0 && u.MaximumWeight > 0)
        //     .WithMessage("é necessário informar um valor para o atributo maximumWeight")
        //     .Must(u => u.WeightUnit != 0 && u.MaximumWeight == 0)
        //     .WithMessage("é necessário informar uma unidade de peso");
    }
}