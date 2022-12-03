using Microsoft.EntityFrameworkCore;
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

    public List<CustomerOwner>? GetOwnerCustomers(Guid ownerId)
    {
        string query = $@"
select * 
  from customer_owner co 
 where co.owner_id  = '{ownerId}'
   and exists (
      select b.customer_id, count(b.owner_id) count_owner
        from customer_owner b
       where b.customer_id in (
              select a.customer_id
                from customer_owner a
               where a.owner_id = co.owner_id)
         and b.customer_id = co.customer_id
    group by b.customer_id
      having count(b.owner_id) = 1)".Replace("\n", "").Trim();

        return _dbSet.FromSqlRaw(query).IgnoreAutoIncludes().ToList();
    }

    public List<CustomerOwner> DeleteCustomersNotLinkedToAnotherOwner(Guid ownerId)
    {
        List<CustomerOwner>? customersToRemove = GetOwnerCustomers(ownerId);
        if (customersToRemove is null) return new();

        _dbSet.RemoveRange(customersToRemove);

        return customersToRemove;
    }
}