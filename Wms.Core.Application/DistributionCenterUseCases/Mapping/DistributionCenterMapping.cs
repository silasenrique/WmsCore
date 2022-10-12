using Mapster;
using Wms.Core.Application.DistributionCenterUseCases.Commands.Create;
using Wms.Core.Application.DistributionCenterUseCases.Commands.Delete;
using Wms.Core.Application.DistributionCenterUseCases.Commands.Update;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.DistributionCenterUseCases.Mapping;

public class DistributionCenterMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<DistributionCenterCreateCommand, DistributionCenter>()
        //     .MapToConstructor(true)
        //     .ConstructUsing(scr => new DistributionCenter(scr.Code, scr.Name, scr.Document));

        // config.NewConfig<DistributionCenterUpdateCommand, DistributionCenter>()
        //     .MapToConstructor(true)
        //     .ConstructUsing(scr => new DistributionCenter(scr.Id, scr.Code, scr.Name, scr.Document));

        // config.NewConfig<DistributionCenterDeleteCommand, DistributionCenter>()
        //     .MapToConstructor(true)
        //     .ConstructUsing(src => new DistributionCenter(src.Code));

        config.NewConfig<DistributionCenter, DistributionCenterResponse>()
              .Map(dest => dest.CreationDate,
                   src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.CreationDate).ToLocalTime())
              .Map(dest => dest.LastChangeDate,
                   src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.LastChangeDate).ToLocalTime());
    }
}