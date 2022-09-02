using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

public interface IOwnerRepository : IGenericRepository<Owner>
{
    Task<Owner?> GetByCode(string code);
    Task<Owner?> GetByDocument(string document);
    Task<Owner?> DocumentIsAlreadyAllocated(string code, string document);
}