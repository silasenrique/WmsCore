using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.EntityRepository;

public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
{
    public ProviderRepository(ApplicationContext dbContext) : base(dbContext) { }
}