using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ShippingUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ShippingUseCases.Commands.Update;

public class ShippingUpdateCommandHandler : ICommandHandler<ShippingUpdateCommand, ErrorOr<ShippingResponse>>
{
    private readonly IShippingRepository _repository;

    public ShippingUpdateCommandHandler(IShippingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<ShippingResponse>> Handle(ShippingUpdateCommand command, CancellationToken cancellationToken)
    {
        Shipping? shipping = new Shipping(
            command.Id,
            command.Code,
            command.Name,
            command.Document,
            command.TypeDoc,
            command.Status);
        
        await _repository.Update(shipping);

        shipping = await _repository.GetByCode(command.Code);

        return new ShippingResponse (
            shipping.Id,
            shipping.Code,
            shipping.Document,
            shipping.Name,
            shipping.TypeDoc,
            shipping.Status,
            shipping.CreationDate,
            shipping.LastChangeDate);
    }
}