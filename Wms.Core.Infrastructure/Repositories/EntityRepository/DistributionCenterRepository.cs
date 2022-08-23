using System.Linq.Expressions;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.EntityRepository;

public class DistributionCenterRepository : GenericRepository<DistributionCenter>, IDistributionCenterRepository
{
    public DistributionCenterRepository(ApplicationContext context) : base(context) { }

    public async Task<DistributionCenter?> GetByCode(string code)
    {
        Expression<Func<DistributionCenter, bool>> expression = e => e.Code == code;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }
}