using Mapster;
using Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Create;
using Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Delete;
using Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Update;
using Wms.Core.Application.Contracts.EntityContract.Provider;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.Common.Mapping.EntityMapping;

public class ProviderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProviderCreateCommand, Provider>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Provider(scr.Code, scr.Name, scr.Document, (TypeEntity)scr.TypeDoc, (GlobalStatus)scr.Status));

        config.NewConfig<ProviderUpdateCommand, Provider>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Provider(scr.Id, scr.Code, scr.Name, scr.Document, (TypeEntity)scr.TypeDoc, (GlobalStatus)scr.Status));

        config.NewConfig<ProviderDeleteCommand, Provider>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Provider(scr.Code));

        config.NewConfig<Provider, ProviderResponse>()
            .Map(dest => dest.CreationDate,
                 src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.CreationDate).ToLocalTime())
            .Map(dest => dest.LastChangeDate,
                 src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.LastChangeDate).ToLocalTime());
    }
}