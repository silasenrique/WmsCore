using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

public interface IProviderRepository : IGenericRepository<Provider>
{
    Task<Provider?> GetByCode(string code);
    Task<Provider?> GetByDocument(string document);
    Task<Provider?> DocumentIsAlreadyAllocated(string code, string document);
}