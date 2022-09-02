using System.Linq.Expressions;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.EntityRepository;

public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
{
    Expression<Func<Provider, bool>> expression { get; set; }

    public ProviderRepository(ApplicationContext dbContext) : base(dbContext) { }

    public async Task<Provider?> GetByCode(string code)
    {
        expression = e => e.Code == code;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }

    public async Task<Provider?> GetByDocument(string document)
    {
        expression = e => e.Document == document;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }

    public async Task<Provider?> DocumentIsAlreadyAllocated(string code, string document)
    {
        expression = e => e.Code != code && e.Document == document;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }
}