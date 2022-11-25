using Wms.Core.Domain.Owner.Models;
using Wms.Core.Persistence.Common.Repository;

namespace Wms.Core.Persistence.CustomerPersistence.Repository;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    void AddRange(List<Customer> customers);
    Customer? GetByIdWithoutInclude(Guid id);
}