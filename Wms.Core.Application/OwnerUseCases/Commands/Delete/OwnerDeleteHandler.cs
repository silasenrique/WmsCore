using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Commands.Delete;

public class OwnerDeleteHandler : ICommandHandler<OwnerDeleteCommand, Error?>
{
    private readonly IMapper _mapper;
    private readonly IOwnerRepository _repository;

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