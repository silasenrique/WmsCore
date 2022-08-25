using System.Linq.Expressions;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.EntityRepository;

public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(ApplicationContext context) : base(context) { }

    public async Task<Owner?> GetByCode(string code)
    {
        Expression<Func<Owner, bool>> expression = e => e.Code == code;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }
}