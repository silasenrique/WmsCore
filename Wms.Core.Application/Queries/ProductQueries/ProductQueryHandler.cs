using System.Linq.Expressions;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Product.Product;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Enums;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Application.Queries.ProductQueries;

public class ProductQueryHandler : ICommandHandler<ProductQuery, List<ProductResponse>>
{
    readonly IProductRepository _repository;
    readonly IMapper _mapper;

    public ProductQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(ProductQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Product, bool>> expression = e =>
            (e.Id == query.Id || query.Id == 0) &&
            (e.Code == query.Code || query.Code == null) &&
            (e.OwnerCode == query.OwnerCode || query.OwnerCode == null) &&
            (e.Status == (GlobalStatus)query.Status || query.Status == 0) &&
            (e.Description.Contains(query.Description) || query.Description == null)
        ;

        return _mapper.Map<List<ProductResponse>>(await _repository.Get(expression));
    }
}