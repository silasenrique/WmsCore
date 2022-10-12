using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Application.UnitizerTypeUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.DistributionCenterUseCases.Mapping;

public static class ToDistributionCenter
{
    public static DistributionCenterResponse ToResponse(DistributionCenter distributionCenter)
    {
        return new DistributionCenterResponse(distributionCenter.Id, 
                   distributionCenter.Code,
                   distributionCenter.Name, 
                   distributionCenter.Document,
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(distributionCenter.CreationDate).ToLocalTime().ToString(), 
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(distributionCenter.LastChangeDate).ToLocalTime().ToString());
    }

    public static DistributionCenter ToCreateDistributionCenter(DistributionCenterResponse response)
    {
        return new DistributionCenter(
            response.Code,
            response.Name,
            response.Document);;
    }
}