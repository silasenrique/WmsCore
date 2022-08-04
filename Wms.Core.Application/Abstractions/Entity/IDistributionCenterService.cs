using ErrorOr;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.Abstractions.Entity;


public interface IDistributionCenterService
{
    Task<ErrorOr<DistributionCenter>> Create(DistributionCenter distributionCenter);
    Task<ErrorOr<DistributionCenter>> Update(DistributionCenter distributionCenter);
    Task<IEnumerable<DistributionCenter>> Get(DistributionCenter distributionCenter);
    Task<Error?> Delete(string code);

    //TODO: adicionar uma funcionalidade para limpeza e deleção de sites
}