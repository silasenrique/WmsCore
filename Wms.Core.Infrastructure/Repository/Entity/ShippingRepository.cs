using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository.Entity;

public class ShippingRepository : GenericRepository<Shipping>, IShippingRepository
{
    public ShippingRepository(ApplicationContext dbContext) : base(dbContext) { }
}