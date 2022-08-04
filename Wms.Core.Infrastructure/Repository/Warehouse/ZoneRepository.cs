using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Abstractions.Warehouse;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository;

public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
{
    public ZoneRepository(ApplicationContext dbContext) : base(dbContext) { }
}