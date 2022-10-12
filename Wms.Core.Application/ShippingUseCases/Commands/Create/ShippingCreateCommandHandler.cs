using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ShippingUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ShippingUseCases.Commands.Create;

public class ShippingCreateCommandHandler : ICommandHandler<ShippingCreateCommand, ErrorOr<ShippingResponse>>
{
    readonly IShippingRepository _repository;

    public ShippingCreateCommandHandler(IShippingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<ShippingResponse>> Handle(ShippingCreateCommand command, CancellationToken cancellationToken)
    {
        Shipping? shipping = new Shipping(
            command.Code,
            command.Name,
            command.Document,
            command.TypeDoc,
            command.Status);
        
        await _repository.Insert(shipping);

        shipping = await _repository.GetByCode(command.Code);

        return new ShippingResponse (
            shipping.Id,
            shipping.Code,
            shipping.Document,
            shipping.Name,
            shipping.TypeDoc,
            shipping.Status,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(shipping.CreationDate).ToString(),
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(shipping.LastChangeDate).ToString());
    }
}