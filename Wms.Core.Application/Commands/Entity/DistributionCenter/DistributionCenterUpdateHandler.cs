using System.Linq.Expressions;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Wms.Core.Application.Commands.Entity.DistributionCenter.Common;
using Wms.Core.Application.DTOs;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.DistributionCenterCommand;

public class DistributionCenterUpdateHandler : IRequestHandler<DistributionCenterUpdateCommand, ErrorOr<DistributionCenterDTO>>
{
    readonly IDistributionCenterRepository _repository;
    readonly ISender _mediator;
    readonly IMapper _mapper;

    public DistributionCenterUpdateHandler(IDistributionCenterRepository distributionCenterRepository, ISender mediator, IMapper mapper)
    {
        _repository = distributionCenterRepository;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ErrorOr<DistributionCenterDTO>> Handle(DistributionCenterUpdateCommand command, CancellationToken cancellationToken)
    {
        var newDistributionCenter = new DistributionCenter(
            command.Id,
            command.Code,
            command.Name,
            command.Document);

        Expression<Func<DistributionCenter, bool>> expression = e => e.Code == newDistributionCenter.Code;

        var getCd = await _repository.Get(expression);
        if (!getCd.Any())
        {
            return await _mediator.Send(command, cancellationToken);
        }

        newDistributionCenter.LastChangeDate = getCd.FirstOrDefault()!.LastChangeDate;

        await _repository.Update(newDistributionCenter);

        getCd = await _repository.Get(expression);

        return _mapper.Map<DistributionCenterDTO>(getCd.FirstOrDefault()!);
    }
}