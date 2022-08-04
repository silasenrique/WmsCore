using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Abstractions.ProductAbstraction;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository.ProductRepository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationContext context) : base(context) { }
}