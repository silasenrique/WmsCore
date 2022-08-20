using ErrorOr;
using MapsterMapper;
using MediatR;
using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Create;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using Wms.Core.Application.Queries.Entity.DistributionCenterQueries;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Update;

public class DistributionCenterUpdateHandler : ICommandHandler<DistributionCenterUpdateCommand, ErrorOr<DistributionCenterResponse>>
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

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterUpdateCommand command, CancellationToken cancellationToken)
    {
        var updated = _mapper.Map<DistributionCenter>(command);

        var alguma = _mapper.Map<DistributionCenterByCodeQuery>(command);

        if (await _mediator.Send(alguma) is null)
        {
            return await _mediator.Send(_mapper.Map<DistributionCenterCreateCommand>(command));
        }

        await _repository.Update(updated);

        return _mapper.Map<DistributionCenterResponse>(await _mediator.Send(alguma));
    }
}