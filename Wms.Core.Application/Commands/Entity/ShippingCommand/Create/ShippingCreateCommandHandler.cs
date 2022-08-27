using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Entity.Shipping;
using Wms.Core.Application.Errors;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.Entity.ShippingCommand.Create;

public class ShippingCreateCommandHandler : ICommandHandler<ShippingCreateCommand, ErrorOr<ShippingResponse>>
{
    readonly IShippingRepository _repository;
    readonly IMapper _mapper;

    public ShippingCreateCommandHandler(IShippingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ShippingResponse>> Handle(ShippingCreateCommand command, CancellationToken cancellationToken)
    {
        if (await _repository.GetByCode(command.Code) is not null)
        {
            return ShippingErrors.CodeHasBeenEnteredBefore;
        }

        if (await _repository.GetByDocument(command.Document) is not null)
        {
            return ShippingErrors.DocumentHasBeenEnteredBefore;
        }

        await _repository.Insert(_mapper.Map<Shipping>(command));

        return _mapper.Map<ShippingResponse>(await _repository.GetByCode(command.Code));
    }
}