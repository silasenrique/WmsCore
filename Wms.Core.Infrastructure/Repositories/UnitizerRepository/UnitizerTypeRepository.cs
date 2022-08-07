using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Context;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Infrastructure.Repositories.UnitizerRepository;

public class UnitizerTypeRepository : GenericRepository<UnitizerType>, IUnitizerTypeRepository
{
    public UnitizerTypeRepository(ApplicationContext dbContext) : base(dbContext) { }
}