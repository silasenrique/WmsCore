using FluentValidation;

namespace Wms.Core.Application.CustomerServices.Commands.Create.Validations;

public class CreateOrReferACustomerToAnOwnerValidation : AbstractValidator<CreateOrReferACustomerToAnOwner>
{
    CreateOrReferACustomerToAnOwnerValidation()
    {
        RuleFor(c => c)
            .Must(c => c.ExistingCustomers is null && c.NewCustomers is null)
            .WithMessage("É necessário informar um Customer para vincular ao cliente. Crie ou referencie um já existente!");
    }
}