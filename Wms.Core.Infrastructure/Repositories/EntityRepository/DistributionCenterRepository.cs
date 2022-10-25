using System.Linq.Expressions;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.EntityRepository;

public class DistributionCenterRepository : GenericRepository<DistributionCenter>, IDistributionCenterRepository
{
    Expression<Func<DistributionCenter, bool>> expression { get; set; }

    public DistributionCenterRepository(ApplicationContext context) : base(context) { }

    public async Task<DistributionCenter?> GetByCode(string code)
    {
        expression = e => e.Code == code;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }

    public async Task<DistributionCenter?> GetByDocument(string document)
    {
        expression = e => e.Document == document;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }

    public async Task<DistributionCenter?> GetById(int id)
    {
        expression = e => e.Id == id;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }
    
}