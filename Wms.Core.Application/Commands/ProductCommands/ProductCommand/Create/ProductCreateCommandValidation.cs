using FluentValidation;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Create;

public class ProductCreateCommandValidation : AbstractValidator<ProductCreateCommand>
{
    public ProductCreateCommandValidation()
    {

    }
}