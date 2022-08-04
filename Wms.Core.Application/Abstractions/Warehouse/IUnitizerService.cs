using ErrorOr;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Application.Abstractions.Warehouse;

public interface IUnitizerService
{
    Task<ErrorOr<Unitizer>> Create(Unitizer unitizer);
    Task<ErrorOr<Unitizer>> Update(Unitizer unitizer);
    Task<Error?> Delete(Unitizer unitizer);
    Task<IEnumerable<Unitizer>> Get(Unitizer unitizer);
}