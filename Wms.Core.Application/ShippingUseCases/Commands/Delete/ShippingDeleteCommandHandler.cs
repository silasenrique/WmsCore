using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ShippingUseCases.Commands.Delete;

public class ShippingDeleteCommandHandler : ICommandHandler<ShippingDeleteCommand, Error?>
{
    readonly IShippingRepository _repository;
    readonly IMapper _mapper;

    public ShippingDeleteCommandHandler(IShippingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Error?> Handle(ShippingDeleteCommand command, CancellationToken cancellationToken)
    {
        await _repository.Delete(await _repository.GetByCode(command.Code));

        return null;
    }
}