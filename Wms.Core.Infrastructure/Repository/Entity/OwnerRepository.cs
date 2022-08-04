using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository.Entity;

public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(ApplicationContext context) : base(context) { }
}