using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Commands.Create;

public class OwnerCreateHandler : ICommandHandler<OwnerCreateCommand, ErrorOr<OwnerResponse>>
{
    private readonly IMapper _mapper;
    private readonly IOwnerRepository _repository;

    public OwnerCreateHandler(IOwnerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<OwnerResponse>> Handle(OwnerCreateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Insert(_mapper.Map<Owner>(command));

        return _mapper.Map<OwnerResponse>(await _repository.GetByCode(command.Code));
    }
}