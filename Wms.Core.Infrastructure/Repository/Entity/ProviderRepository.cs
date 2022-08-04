using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Abstractions.Entity;

namespace Wms.Core.Infrastructure.Repository;

public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
{
    public ProviderRepository(ApplicationContext dbContext) : base(dbContext) { }
}