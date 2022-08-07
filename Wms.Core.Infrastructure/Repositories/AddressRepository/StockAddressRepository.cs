using Wms.Core.Domain.Entities.Address;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.AddressRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.AddressRepository;

public class StockAddressRepository : GenericRepository<StockAddress>, IStockAddressRepository
{
    public StockAddressRepository(ApplicationContext dbContext) : base(dbContext) { }
}