using Mapster;
using Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Create;
using Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Delete;
using Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Update;
using Wms.Core.Application.Contracts.UnitizerContract;
using Wms.Core.Domain.Entities.Unitizer;

namespace Wms.Core.Application.Common.Mapping.UnitizerMapping;

public class UnitizerTypeMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<UnitizerTypeCreateCommand, UnitizerType>()
        //     .MapToConstructor(true)
        //     .ConstructUsing(src => new UnitizerType(src.Code,
        //                                             src.Description,
        //                                             src.MaximumWeight,
        //                                             src.WeightUnit,
        //                                             src.Height,
        //                                             src.HeightUnit,
        //                                             src.Width,
        //                                             src.WidthUnit,
        //                                             src.Length,
        //                                             src.LengthUnit));

        // config.NewConfig<UnitizerTypeUpdateCommand, UnitizerType>()
        //    .MapToConstructor(true)
        //    .ConstructUsing(src => new UnitizerType(src.Id,
        //                                            src.Code,
        //                                            src.Description,
        //                                            src.MaximumWeight,
        //                                            src.WeightUnit,
        //                                            src.Height,
        //                                            src.HeightUnit,
        //                                            src.Width,
        //                                            src.WidthUnit,
        //                                            src.Length,
        //                                            src.LengthUnit));

        // config.NewConfig<UnitizerTypeDeleteCommand, UnitizerType>()
        //     .MapToConstructor(true)
        //     .ConstructUsing(src => new UnitizerType(src.Code));

        // config.NewConfig<UnitizerType, UnitizerTypeResponse>()
        //       .Map(dest => dest.CreationDate,
        //            src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.CreationDate).ToLocalTime())
        //       .Map(dest => dest.LastChangeDate,
        //            src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.LastChangeDate).ToLocalTime());
    }
}