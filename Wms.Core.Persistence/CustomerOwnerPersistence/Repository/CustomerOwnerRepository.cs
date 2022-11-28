using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Owner.Models;
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

    public void GetOwnerCustomer(Guid ownerId)
    {
        var query = $@"
        select id customer_id
          from customer, (
                select customer_id,
                       count(owner_id) count_owner
                  from customer_owner
                 where customer_id in (
                        select customer_id
                          from customer_owner
                          where owner_id = '{ownerId}')
                group by customer_id
                having count(owner_id) = 1
            ) d
        where id = customer_id".Replace("\n", " ").Trim();

        var abc = _dbSet.FromSqlRaw(query).ToList();

        System.Console.WriteLine(abc.Count);
    }
}