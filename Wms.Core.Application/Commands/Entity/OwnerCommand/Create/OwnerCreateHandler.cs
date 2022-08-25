using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.ApplicationErrors;
using Wms.Core.Application.Contracts.Entity.Owner;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.Entity.OwnerCreateCommand.Create;

public class OwnerCreateHandler : ICommandHandler<OwnerCreateCommand, ErrorOr<OwnerResponse>>
{
    readonly IOwnerRepository _repository;
    readonly IMapper _mapper;

    public OwnerCreateHandler(IOwnerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<OwnerResponse>> Handle(OwnerCreateCommand command, CancellationToken cancellationToken)
    {
        if (await _repository.GetByCode(command.Code) is not null)
        {
            return OwnerErros.CodeHasBeenEnteredBefore;
        }

        await _repository.Insert(_mapper.Map<Owner>(command));

        return _mapper.Map<OwnerResponse>(await _repository.GetByCode(command.Code));
    }
}