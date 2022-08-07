using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.AddressRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.AddressRepository;

public class TypeAddressRepository : GenericRepository<TypeAddress>, ITypeAddressRepository
{
    public TypeAddressRepository(ApplicationContext dbContext) : base(dbContext) { }
}