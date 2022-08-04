using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Abstractions.Warehouse;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository;

public class StockRepository : GenericRepository<Stock>, IStockRepository
{
    public StockRepository(ApplicationContext dbContext) : base(dbContext) { }
}