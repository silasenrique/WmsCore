using Mapster;
using Wms.Core.Application.Commands.Entity.OwnerCommand.Delete;
using Wms.Core.Application.Commands.Entity.OwnerCommand.Update;
using Wms.Core.Application.Commands.Entity.OwnerCreateCommand.Create;
using Wms.Core.Application.Contracts.Entity.Owner;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.Common.Mapping.Entity;

public class OwnerMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OwnerCreateCommand, Owner>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Owner(scr.Code, scr.Name, scr.Document, (TypeEntity)scr.TypeDoc, (GlobalStatus)scr.Status));

        config.NewConfig<OwnerUpdateCommand, Owner>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Owner(scr.Id, scr.Code, scr.Name, scr.Document, (TypeEntity)scr.TypeDoc, (GlobalStatus)scr.Status));

        config.NewConfig<OwnerDeleteCommand, Owner>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Owner(scr.Code));

        config.NewConfig<Owner, OwnerResponse>()
            .Map(dest => dest.CreationDate,
                 src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.CreationDate).ToLocalTime())
            .Map(dest => dest.LastChangeDate,
                 src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.LastChangeDate).ToLocalTime());
    }
}