using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ShippingUseCases.Commands.Delete;

public class ShippingDeleteCommandHandler : ICommandHandler<ShippingDeleteCommand, Error?>
{
    private readonly IShippingRepository _repository;

    public ShippingDeleteCommandHandler(IShippingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(ShippingDeleteCommand command, CancellationToken cancellationToken)
    {
        Shipping? shipping =  await _repository.GetByCode(command.Code);
        if (shipping is null) return null;
        
        await _repository.Delete(shipping);

        return null;
    }
}