using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository.Entity;

public class DistributionCenterRepository : GenericRepository<DistributionCenter>, IDistributionCenterRepository
{
    public DistributionCenterRepository(ApplicationContext context) : base(context) { }
}