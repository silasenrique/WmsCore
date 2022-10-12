using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Commands.Update;

public class OwnerUpdateHandler : ICommandHandler<OwnerUpdateCommand, ErrorOr<OwnerResponse>>
{
    private readonly IOwnerRepository _repository;

    public OwnerUpdateHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<OwnerResponse>> Handle(OwnerUpdateCommand command, CancellationToken cancellationToken)
    {
        Owner? owner = new Owner(
            command.Id,
            command.Code,
            command.Name,
            command.Document,
            command.TypeDoc,
            command.Status);
        
        await _repository.Update(owner);

        owner = await _repository.GetByCode(owner.Code);
        
        return new OwnerResponse (
            owner.Id,
            owner.Code,
            owner.Document,
            owner.Name,
            owner.TypeDoc,
            owner.Status,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(owner.CreationDate).ToString(),
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(owner.LastChangeDate).ToString());;
    }
}