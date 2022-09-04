using System.Linq.Expressions;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.UnitizerRepository;

public class UnitizerTypeRepository : GenericRepository<UnitizerType>, IUnitizerTypeRepository
{
    private Expression<Func<UnitizerType, bool>> _expression;
    
    public UnitizerTypeRepository(ApplicationContext dbContext) : base(dbContext) { }

    public async Task<UnitizerType?> GetByCode(string code)
    {
        _expression = e => e.Code == code;
        
        var unitizer = await Get(_expression);

        return unitizer.FirstOrDefault();
    }
}