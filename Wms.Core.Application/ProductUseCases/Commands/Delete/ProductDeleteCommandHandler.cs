using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Application.ProductUseCases.Commands.Delete;

public class ProductDeleteCommandHandler : ICommandHandler<ProductDeleteCommand, Error?>
{
    readonly IProductRepository _repository;

    public ProductDeleteCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(ProductDeleteCommand command, CancellationToken cancellationToken)
    {
        await _repository.Delete(await _repository.GetByOwnerAndCode(command.Code, command.OwnerCode));

        return null;
    }
}