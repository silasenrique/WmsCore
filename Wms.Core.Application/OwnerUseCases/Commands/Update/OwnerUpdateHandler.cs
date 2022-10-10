using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Commands.Update;

public class OwnerUpdateHandler : ICommandHandler<OwnerUpdateCommand, ErrorOr<OwnerResponse>>
{
    readonly IOwnerRepository _repository;
    readonly IMapper _mapper;

    public OwnerUpdateHandler(IOwnerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<OwnerResponse>> Handle(OwnerUpdateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Update(_mapper.Map<Owner>(command));

        return _mapper.Map<OwnerResponse>(await _repository.GetByCode(command.Code));
    }
}