using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Abstractions.Warehouse;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository;

public class UnitizerRepository : GenericRepository<Unitizer>, IUnitizerRepository
{
    public UnitizerRepository(ApplicationContext dbContext) : base(dbContext) { }
}