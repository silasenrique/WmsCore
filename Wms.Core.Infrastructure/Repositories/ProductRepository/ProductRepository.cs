using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.ProductRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationContext context) : base(context) { }
}