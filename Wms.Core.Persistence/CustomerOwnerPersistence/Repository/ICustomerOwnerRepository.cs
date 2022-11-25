using Wms.Core.Domain.Owner.Relationship;
using Wms.Core.Persistence.Common.Repository;

namespace Wms.Core.Persistence.CustomerOwnerPersistence.Repository;

public interface ICustomerOwnerRepository : IGenericRepository<CustomerOwner>
{
    void AddRange(List<CustomerOwner> customerOwner);
}