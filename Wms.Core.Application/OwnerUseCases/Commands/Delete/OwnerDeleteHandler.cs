using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Commands.Delete;

public class OwnerDeleteHandler : ICommandHandler<OwnerDeleteCommand, Error?>
{
    readonly IOwnerRepository _repository;
    readonly IMapper _mapper;

    public OwnerDeleteHandler(IOwnerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Error?> Handle(OwnerDeleteCommand command, CancellationToken cancellationToken)
    {
        await _repository.Delete(await _repository.GetByCode(command.Code));

        return null;
    }
}