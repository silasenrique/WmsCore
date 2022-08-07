using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.ProductRepository;

public class ProductPackagingRepository : GenericRepository<ProductPackaging>, IProductPackagingRepository
{
    public ProductPackagingRepository(ApplicationContext context) : base(context) { }
}