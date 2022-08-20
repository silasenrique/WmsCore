using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using Wms.Core.Application.Abstractions.Messaging;
using MapsterMapper;
using Wms.Core.Domain.Entities.Entity;
using ErrorOr;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using MediatR;
using Wms.Core.Application.Queries.Entity.DistributionCenterQueries;
using Wms.Core.Application.ApplicationErrors;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Create;

public class DistributionCenterCreateHandler : ICommandHandler<DistributionCenterCreateCommand, ErrorOr<DistributionCenterResponse>>
{
    readonly IDistributionCenterRepository _distributionCenterRepository;
    readonly IMapper _mapper;
    readonly ISender _mediator;

    public DistributionCenterCreateHandler(IDistributionCenterRepository distributionCenterRepository, IMapper mapper, ISender mediator)
    {
        _distributionCenterRepository = distributionCenterRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterCreateCommand command, CancellationToken cancellationToken)
    {
        var newDistributionCenter = _mapper.Map<DistributionCenter>(command);

        var alguma = _mapper.Map<DistributionCenterByCodeQuery>(command);

        if (await _mediator.Send(alguma) is not null)
        {
            return DistributionCenterErrors.CodeHasBeenEnteredBefore;
        }

        await _distributionCenterRepository.Insert(newDistributionCenter);

        return _mapper.Map<DistributionCenterResponse>(await _mediator.Send(alguma));
    }
}