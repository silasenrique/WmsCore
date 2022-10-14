using ErrorOr;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.DistributionCenterUseCases.Services.Create;

public interface IDistributionCenterCreateService 
{
    Task<Error?> ValidCreateDistributionCenter(DistributionCenter distributionCenter);
}