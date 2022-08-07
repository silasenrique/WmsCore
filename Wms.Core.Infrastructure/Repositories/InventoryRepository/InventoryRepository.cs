using Wms.Core.Domain.Entities.Inventory;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.InventoryRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.InventoryRepository;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(ApplicationContext dbContext) : base(dbContext) { }
}