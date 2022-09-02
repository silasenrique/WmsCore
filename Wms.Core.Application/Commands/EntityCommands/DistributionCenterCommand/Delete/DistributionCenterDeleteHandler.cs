using ErrorOr;
using MediatR;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Delete;

public class DistributionCenterDeleteHandler : IRequestHandler<DistributionCenterDeleteCommand, Error?>
{
    readonly IDistributionCenterRepository _repository;

    public DistributionCenterDeleteHandler(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(DistributionCenterDeleteCommand command, CancellationToken cancellationToken)
    {
        var cd = await _repository.GetByCode(command.Code);

        if (cd is null) return null;

        await _repository.Delete(cd);

        return null;
    }
}