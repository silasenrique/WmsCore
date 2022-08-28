using System.Linq.Expressions;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.ProductRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    Expression<Func<Product, bool>> _expression { get; set; }

    public ProductRepository(ApplicationContext context) : base(context) { }

    public async Task<Product?> GetByOwnerAndCode(string code, string ownerCode)
    {
        _expression = e => e.Code == code && e.OwnerCode == ownerCode;

        var product = await Get(_expression);

        return product.FirstOrDefault();
    }
}