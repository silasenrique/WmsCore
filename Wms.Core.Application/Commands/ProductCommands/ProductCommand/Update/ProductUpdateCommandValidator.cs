using FluentValidation;
using Wms.Core.Application.Commands.ProductCommands.ProductCommand.Common;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Update;

public class ProductCreateCommandValidator : AbstractValidator<ProductUpdateCommand>
{
    readonly IProductRepository _repository;

    public ProductCreateCommandValidator(IProductRepository repository)
    {
        _repository = repository;
        Validate();
    }

    void Validate()
    {
        Include(new ProductCommonWriteCommandValidator());

        RuleFor(p => p.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("não pode ser vazio ou nulo")
            .GreaterThan(0)
            .WithMessage("precisa ser maior que zero");

        RuleFor(p => new { p.Id, p.Code, p.OwnerCode })
            .MustAsync(async (product, cancellation) => { var result = await CodeAlreadyLinkedToOwner(product.Id, product.OwnerCode, product.Code); return result; })
            .WithMessage("código do produto já está vinculado em outro registro");
    }

    async Task<bool> CodeAlreadyLinkedToOwner(int id, string ownerCode, string code)
    {
        var get = await _repository.GetByOwnerAndCode(code, ownerCode);

        if (get is null) return false;

        return get.Id != id;
    }
}