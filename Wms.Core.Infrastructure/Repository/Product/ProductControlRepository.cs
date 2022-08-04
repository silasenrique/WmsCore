using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Abstractions.ProductAbstraction;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository.ProductRepository;

public class ProductControlRepository : GenericRepository<ProductControl>, IProductControlRepository
{
    public ProductControlRepository(ApplicationContext context) : base(context) { }
}