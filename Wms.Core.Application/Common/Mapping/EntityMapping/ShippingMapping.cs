using Mapster;
using Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Create;
using Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Delete;
using Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Update;
using Wms.Core.Application.Contracts.EntityContract.Shipping;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.Common.Mapping.EntityMapping;

public class ShippingMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ShippingCreateCommand, Shipping>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Shipping(scr.Code, scr.Name, scr.Document, (TypeEntity)scr.TypeDoc, (GlobalStatus)scr.Status));

        config.NewConfig<ShippingUpdateCommand, Shipping>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Shipping(scr.Id, scr.Code, scr.Name, scr.Document, (TypeEntity)scr.TypeDoc, (GlobalStatus)scr.Status));

        config.NewConfig<ShippingDeleteCommand, Shipping>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Shipping(scr.Code));

        config.NewConfig<Shipping, ShippingResponse>()
            .Map(dest => dest.CreationDate,
                 src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.CreationDate).ToLocalTime())
            .Map(dest => dest.LastChangeDate,
                 src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.LastChangeDate).ToLocalTime());
    }
}