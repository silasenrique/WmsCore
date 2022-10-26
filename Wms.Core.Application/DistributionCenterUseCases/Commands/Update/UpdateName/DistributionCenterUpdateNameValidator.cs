using FluentValidation;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update.UpdateName;

public class DistributionCenterUpdateNameValidator : AbstractValidator<DistributionCenterUpdateNameCommand>
{
    public DistributionCenterUpdateNameValidator ()
    {
        RuleFor(cd => cd.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} deve ser informado");

        RuleFor(cd => cd.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} deve ser informado")
            .Must(cd => cd.Length is < 10 or > 100).WithMessage("{PropertyName} ter no minimo 10 caracteres e no maximo 100");
    }
}