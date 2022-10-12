using System.Linq.Expressions;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProductUseCases.Contract;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Application.ProductUseCases.Queries;

public class ProductQueryHandler : ICommandHandler<ProductQuery, List<ProductResponse>>
{
    readonly IProductRepository _repository;

    public ProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductResponse>> Handle(ProductQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Product, bool>> expression = e =>
            (e.Id == query.Id || query.Id == null) &&
            (e.Code == query.Code || query.Code == null) &&
            (e.OwnerCode == query.OwnerCode || query.OwnerCode == null) &&
            (e.Status == query.Status || query.Status == 0) &&
            (e.Description.Contains(query.Description) || query.Description == null);

        List<ProductResponse> response = new();
        IEnumerable<Product> result = await _repository.Get(expression);
        
        response.AddRange(
            result.Select(prod => new ProductResponse(
                prod.Id,
                prod.Code,
                prod.Description,
                prod.Status,
                prod.OwnerCode,
                new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(prod.LastChangeDate).ToLocalTime().ToString(),
                new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(prod.LastChangeDate).ToLocalTime().ToString())));

        return response;
    }
}