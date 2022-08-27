using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

public interface IShippingRepository : IGenericRepository<Shipping>
{
    Task<Shipping?> GetByCode(string code);
    Task<Shipping?> GetByDocument(string document);
}