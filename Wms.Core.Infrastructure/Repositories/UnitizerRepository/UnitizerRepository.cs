using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.UnitizerRepository;

public class UnitizerRepository : GenericRepository<Unitizer>, IUnitizerRepository
{
    public UnitizerRepository(ApplicationContext dbContext) : base(dbContext) { }
}