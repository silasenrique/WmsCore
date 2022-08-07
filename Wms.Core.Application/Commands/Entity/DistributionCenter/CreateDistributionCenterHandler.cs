using System.Linq.Expressions;
using ErrorOr;
using MediatR;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.DistributionCenterCommand;

public class DistributionCenterCreateHandler : IRequestHandler<CreateCommand, DistributionCenterDTO>
{
    readonly IDistributionCenterRepository _distributionCenterRepository;

    public DistributionCenterCreateHandler(IDistributionCenterRepository distributionCenterRepository)
    {
        _distributionCenterRepository = distributionCenterRepository;
    }

    public async Task<DistributionCenterDTO> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        var newDistributionCenter = new DistributionCenter
        {
            Code = command.Code,
            Name = command.Name,
            Document = command.Document
        };

        await _distributionCenterRepository.Insert(newDistributionCenter);

        Expression<Func<DistributionCenter, bool>> expression = e => e.Code == newDistributionCenter.Code;

        var getCd = await _distributionCenterRepository.Get(expression);
        var cd = getCd.FirstOrDefault();

        return new DistributionCenterDTO
        {
            Id = cd!.Id,
            Code = cd.Code,
            Name = cd.Name,
            Document = cd.Document
        };
    }
}