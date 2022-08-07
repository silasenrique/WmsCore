using System.Linq.Expressions;
using ErrorOr;
using MediatR;
using Wms.Core.Application.Errors.EntityErrors;
using Wms.Core.Application.Commands.Entity.DistributionCenter.Common;
using Wms.Core.Application.DTOs;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.DistributionCenterCommand;

public class DistributionCenterCreateHandler : IRequestHandler<DistributionCenterWriteCommand, ErrorOr<DistributionCenterDTO>>
{
    readonly IDistributionCenterRepository _distributionCenterRepository;

    public DistributionCenterCreateHandler(IDistributionCenterRepository distributionCenterRepository)
    {
        _distributionCenterRepository = distributionCenterRepository;
    }

    public async Task<ErrorOr<DistributionCenterDTO>> Handle(DistributionCenterWriteCommand command, CancellationToken cancellationToken)
    {
        var newDistributionCenter = new DistributionCenter(
            command.Code,
            command.Name,
            command.Document);

        Expression<Func<DistributionCenter, bool>> expression = e => e.Code == newDistributionCenter.Code || e.Document == newDistributionCenter.Document;

        var getCd = await _distributionCenterRepository.Get(expression);
        if (getCd.Count() > 0)
        {
            return EntityErrors.DistributionCenter.CodeHasBeenEnteredBefore;
        }

        await _distributionCenterRepository.Insert(newDistributionCenter);

        getCd = await _distributionCenterRepository.Get(expression);
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