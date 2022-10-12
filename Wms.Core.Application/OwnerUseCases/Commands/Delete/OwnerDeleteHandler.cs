using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Commands.Delete;

public class OwnerDeleteHandler : ICommandHandler<OwnerDeleteCommand, Error?>
{
    private readonly IOwnerRepository _repository;

    public OwnerDeleteHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(OwnerDeleteCommand command, CancellationToken cancellationToken)
    {
        Owner? owner = await _repository.GetByCode(command.Code);
        if (owner is null) return null;
        
        await _repository.Delete(owner);

        return null;
    }
}