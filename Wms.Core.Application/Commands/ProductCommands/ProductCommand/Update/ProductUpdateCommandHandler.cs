using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Product.Product;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Update;

public class ProductUpdateCommandHandler : ICommandHandler<ProductUpdateCommand, ErrorOr<ProductResponse>>
{
    readonly IProductRepository _repository;
    readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductResponse>> Handle(ProductUpdateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Update(_mapper.Map<Product>(command));

        return _mapper.Map<ProductResponse>(await _repository.GetByOwnerAndCode(command.Code, command.OwnerCode));
    }
}