using Wms.Core.Domain.Owner.Relationship;
using Wms.Core.Persistence.Common.Repository;
using Wms.Core.Persistence.Configuration;

namespace Wms.Core.Persistence.CustomerOwnerPersistence.Repository;

public class CustomerOwnerRepository : GenericRepository<CustomerOwner>, ICustomerOwnerRepository
{
    public CustomerOwnerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void AddRange(List<CustomerOwner> customerOwner)
    {
        _context.CustomerOwner.AddRange(customerOwner);
    }
}