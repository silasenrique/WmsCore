using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Abstractions.Warehouse;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repository;

public class TypeAddressRepository : GenericRepository<TypeAddress>, ITypeAddressRepository
{
    public TypeAddressRepository(ApplicationContext dbContext) : base(dbContext) { }
}