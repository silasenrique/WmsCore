using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

public interface IOwnerRepository : IGenericRepository<Owner>
{
    Task<Owner?> GetByCode(string code);
}