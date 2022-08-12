using Mapster;
using Wms.Core.Application.DTOs;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.Common.Mapping;

public class DistributionCenterMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DistributionCenter, DistributionCenterDTO>()
              .Map(
                dest => dest.CreationDate,
                src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.CreationDate).ToLocalTime())
              .Map(
                dest => dest.LastChangeDate,
                src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.LastChangeDate).ToLocalTime());
    }
}