using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.Common.Repository;
using Wms.Core.Persistence.Configuration;

namespace Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(ApplicationDbContext context) : base(context) { }

    public Owner? GetOnlyOwner(Expression<Func<Owner, bool>> expression)
    {
        return _dbSet.Where(expression).IgnoreAutoIncludes().AsNoTracking().FirstOrDefault();
    }
}