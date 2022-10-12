using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Commands.Create;

public class OwnerCreateHandler : ICommandHandler<OwnerCreateCommand, ErrorOr<OwnerResponse>>
{
    private readonly IOwnerRepository _repository;

    public OwnerCreateHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<OwnerResponse>> Handle(OwnerCreateCommand command, CancellationToken cancellationToken)
    {
        Owner? newOwner = new Owner(
            command.Code,
            command.Name,
            command.Document,
            command.TypeDoc,
            command.Status);
        
        await _repository.Insert(newOwner);

        newOwner = await _repository.GetByCode(command.Code);

        return new OwnerResponse (
            newOwner.Id,
            newOwner.Code,
            newOwner.Document,
            newOwner.Name,
            newOwner.TypeDoc,
            newOwner.Status,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(newOwner.CreationDate).ToString(),
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(newOwner.LastChangeDate).ToString());
    }
}