using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Abstractions.Warehouse;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository;

public class UnitizerTypeRepository : GenericRepository<UnitizerType>, IUnitizerTypeRepository
{
    public UnitizerTypeRepository(ApplicationContext dbContext) : base(dbContext) { }
}