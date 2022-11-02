using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProviderUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ProviderUseCases.Commands.Update;

public class ProviderUpdateCommandHandler : ICommandHandler<ProviderUpdateCommand, ErrorOr<ProviderResponse>>
{
    readonly IProviderRepository _repository;

    public ProviderUpdateCommandHandler(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<ProviderResponse>> Handle(ProviderUpdateCommand command, CancellationToken cancellationToken)
    {
        Provider? provider = new Provider(
            command.Id,
            command.Code,
            command.Name,
            command.Document,
            command.TypeDoc,
            command.Status);
        
        await _repository.Update(provider);

        provider = await _repository.GetByCode(command.Code);

        return new ProviderResponse(
            provider.Id,
            provider.Code,
            provider.Document,
            provider.Name,
            provider.TypeDoc,
            provider.Status,
            provider.CreationDate,
            provider.LastChangeDate);
    }
}