using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Abstractions.Warehouse;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository;

public class StockAddressRepository : GenericRepository<StockAddress>, IStockAddressRepository
{
    public StockAddressRepository(ApplicationContext dbContext) : base(dbContext) { }
}