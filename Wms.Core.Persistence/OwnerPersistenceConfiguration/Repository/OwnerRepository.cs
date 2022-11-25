using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.Common.Repository;
using Wms.Core.Persistence.Configuration;

namespace Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(ApplicationDbContext context) : base(context) { }

    public Owner? GetByIdIncludeAll(Guid id)
    {
        Expression<Func<Owner, bool>> _expression = e => e.Id == id;

        return _dbSet.Where(_expression).Include(owner => owner.Customers)
            .ThenInclude(customer => customer.Customer).FirstOrDefault();
    }
}