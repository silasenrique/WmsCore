using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProductUseCases.Contract;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Application.ProductUseCases.Commands.Create;

public class ProductCreateCommandHandler : ICommandHandler<ProductCreateCommand, ErrorOr<ProductResponse>>
{
    readonly IProductRepository _repository;

    public ProductCreateCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<ProductResponse>> Handle(ProductCreateCommand command, CancellationToken cancellationToken)
    {
        Product? product = new Product(
            command.OwnerCode,
            command.Code,
            command.Description,
            command.Status);

        await _repository.Insert(product);

        product = await _repository.GetByOwnerAndCode(command.Code, command.OwnerCode);

        return new ProductResponse(
            product.Id,
            product.Code,
            product.Description,
            product.Status,
            product.OwnerCode,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(product.LastChangeDate).ToLocalTime().ToString(),
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(product.LastChangeDate).ToLocalTime().ToString());
    }
}