using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProviderUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ProviderUseCases.Commands.Create;

public class ProviderCreateCommandHandler : ICommandHandler<ProviderCreateCommand, ErrorOr<ProviderResponse>>
{
    readonly IProviderRepository _repository;

    public ProviderCreateCommandHandler(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<ProviderResponse>> Handle(ProviderCreateCommand command, CancellationToken cancellationToken)
    {
        Provider? provider = new Provider(
            command.Code,
            command.Name,
            command.Document,
            command.TypeDoc,
            command.Status);
        
        await _repository.Insert(provider);

        provider = await _repository.GetByCode(command.Code);

        return new ProviderResponse(
            provider.Id,
            provider.Code,
            provider.Document,
            provider.Name,
            provider.TypeDoc,
            provider.Status,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(provider.LastChangeDate).ToLocalTime().ToString(),
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(provider.LastChangeDate).ToLocalTime().ToString());
    }
}