using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Product.Product;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Create;

public class ProductCreateCommandHandler : ICommandHandler<ProductCreateCommand, ErrorOr<ProductResponse>>
{
    readonly IProductRepository _repository;
    readonly IMapper _mapper;

    public ProductCreateCommandHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductResponse>> Handle(ProductCreateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Insert(_mapper.Map<Product>(command));

        return _mapper.Map<ProductResponse>(await _repository.GetByOwnerAndCode(command.Code, command.OwnerCode));
    }
}