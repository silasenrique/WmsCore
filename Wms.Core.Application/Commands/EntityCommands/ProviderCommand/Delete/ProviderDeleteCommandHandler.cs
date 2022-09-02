using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Delete;

public class ProviderDeleteCommandHandler : ICommandHandler<ProviderDeleteCommand, Error?>
{
    readonly IProviderRepository _repository;

    public ProviderDeleteCommandHandler(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(ProviderDeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.Delete(await _repository.GetByCode(request.Code));

        return null;
    }
}