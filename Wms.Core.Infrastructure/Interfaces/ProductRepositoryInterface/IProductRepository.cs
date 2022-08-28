using Wms.Core.Domain.Entities.Product;

namespace Wms.Core.Infrastructure.Interfaces.ProductRepositoryInterface;

public interface IProductRepository : IGenericRepository<Product>
{

    Task<Product?> GetByOwnerAndCode(string code, string ownerCode);
}