using ErrorOr;
using MediatR;
using Wms.Core.Application.ApplicationErrors;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Delete;

public class DistributionCenterDeleteHandler : IRequestHandler<DistributionCenterDeleteCommand, Error?>
{
    readonly IDistributionCenterRepository _repository;


    public DistributionCenterDeleteHandler(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(DistributionCenterDeleteCommand command, CancellationToken cancellationToken)
    {
        if (command.Id == 0)
        {
            return DistributionCenterErrors.IdIsNecessary;
        }

        // var cd = new DistributionCenter(command.Id);
        // await _repository.Delete(cd);

        return null;
    }
}