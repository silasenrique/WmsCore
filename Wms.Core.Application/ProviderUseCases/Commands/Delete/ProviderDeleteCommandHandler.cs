using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ProviderUseCases.Commands.Delete;

public class ProviderDeleteCommandHandler : ICommandHandler<ProviderDeleteCommand, Error?>
{
    private readonly IProviderRepository _repository;

    public ProviderDeleteCommandHandler(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(ProviderDeleteCommand request, CancellationToken cancellationToken)
    {
       Provider? provider = await _repository.GetByCode(request.Code);
       if (provider is null) return null;
        
        await _repository.Delete(provider);

        return null;
    }
}