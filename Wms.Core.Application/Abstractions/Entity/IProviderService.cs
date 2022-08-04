using ErrorOr;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.Abstractions.Entity;

public interface IProviderService
{
    Task<ErrorOr<Provider>> Create(Provider provider);
    Task<ErrorOr<Provider>> Update(Provider provider);
    Task<IEnumerable<Provider>> Get(Provider provider);
    Task<Error?> Delete(string code);
}