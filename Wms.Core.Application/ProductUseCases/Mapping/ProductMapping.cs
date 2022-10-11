using Mapster;
using Wms.Core.Application.ProductUseCases.Commands.Create;
using Wms.Core.Application.ProductUseCases.Commands.Delete;
using Wms.Core.Application.ProductUseCases.Commands.Update;
using Wms.Core.Application.ProductUseCases.Contract;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProductUseCases.Mapping;

public class ProductMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductCreateCommand, Product>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Product(scr.OwnerCode,
                                               scr.Code,
                                               scr.Description,
                                               (GlobalStatus)scr.Status));

        config.NewConfig<ProductUpdateCommand, Product>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Product(scr.Id,
                                               scr.OwnerCode,
                                               scr.Code,
                                               scr.Description,
                                               (GlobalStatus)scr.Status));

        config.NewConfig<ProductDeleteCommand, Product>()
            .MapToConstructor(true)
            .ConstructUsing(scr => new Product(scr.OwnerCode, scr.Code));

        config.NewConfig<Product, ProductResponse>()
          .Map(dest => dest.CreationDate,
               src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.CreationDate).ToLocalTime())
          .Map(dest => dest.LastChangeDate,
               src => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src.LastChangeDate).ToLocalTime());
    }
}