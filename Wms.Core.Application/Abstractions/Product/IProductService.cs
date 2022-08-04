using ErrorOr;
using Wms.Core.Domain.Entities.Product;

namespace Wms.Core.Application.Abstractions;

public interface IProductService
{
    Task<ErrorOr<Product>> Add(Product product);
    Task<ErrorOr<Product>> Update(Product product);
    Task<Error?> Delete(string owner, string code);
    Task<List<Product>> Get(Product product);
}