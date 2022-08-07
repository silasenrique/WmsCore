using ErrorOr;
using MediatR;
using Wms.Core.Application.Commands.Entity.DistributionCenter.Common;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using Wms.Core.Application.Errors.EntityErrors;

namespace Wms.Core.Application.Commands.DistributionCenterCommand;

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
            return EntityErrors.DistributionCenter.IdIsNecessary;
        }

        var cd = new DistributionCenter(command.Id);

        await _repository.Delete(cd);

        return null;
    }
}