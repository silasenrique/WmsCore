using ErrorOr;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.DistributionCenterUseCases.Services.Update;

public interface IDistributionCenterUpdateService
{
    Task<Error?> ValidateUpdateDistributionCenter(DistributionCenter distributionCenter);
}