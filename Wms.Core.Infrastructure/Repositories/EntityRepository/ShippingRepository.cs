using System.Linq.Expressions;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.EntityRepository;

public class ShippingRepository : GenericRepository<Shipping>, IShippingRepository
{
    Expression<Func<Shipping, bool>> expression { get; set; }

    public ShippingRepository(ApplicationContext dbContext) : base(dbContext) { }

    public async Task<Shipping?> GetByCode(string code)
    {
        expression = e => e.Code == code;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }

    public async Task<Shipping?> GetByDocument(string document)
    {
        expression = e => e.Document == document;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }

    public async Task<Shipping?> DocumentIsAlreadyAllocated(string code, string document)
    {
        expression = e => e.Code != code && e.Document == document;

        var result = await Get(expression);

        return result.FirstOrDefault();
    }
}