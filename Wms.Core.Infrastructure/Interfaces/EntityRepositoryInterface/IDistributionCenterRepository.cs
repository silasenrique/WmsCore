using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

public interface IDistributionCenterRepository : IGenericRepository<DistributionCenter>
{
    Task<DistributionCenter?> GetByCode(string code);
    Task<DistributionCenter?> GetByDocument(string document);
}