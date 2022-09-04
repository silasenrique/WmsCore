using Wms.Core.Domain.Entities.Unitizer;

namespace Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

public interface IUnitizerTypeRepository : IGenericRepository<UnitizerType>
{
    Task<UnitizerType?> GetByCode(string code);
}