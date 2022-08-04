using Wms.Core.Domain.Entities.Product;
using Wms.Core.Infrastructure.Abstractions.ProductAbstraction;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository.ProductRepository;

public class ProductPackagingRepository : GenericRepository<ProductPackaging>, IProductPackagingRepository
{
    public ProductPackagingRepository(ApplicationContext context) : base(context) { }
}