using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Entity.Shipping;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.Entity.ShippingCommand.Update;

public class ShippingUpdateCommandHandler : ICommandHandler<ShippingUpdateCommand, ErrorOr<ShippingResponse>>
{
    readonly IShippingRepository _repository;
    readonly IMapper _mapper;

    public ShippingUpdateCommandHandler(IShippingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ShippingResponse>> Handle(ShippingUpdateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Update(_mapper.Map<Shipping>(command));

        return _mapper.Map<ShippingResponse>(_repository.GetByCode(command.Code));
    }
}