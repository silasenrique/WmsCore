using MapsterMapper;
using MediatR;
using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.Queries.Entity.DistributionCenterQueries;

public class GetByCodeDistributionCenter : ICommandHandler<DistributionCenterByCodeQuery, DistributionCenterResponse>
{
    readonly IMapper _mapper;
    readonly ISender _mediator;

    public GetByCodeDistributionCenter(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<DistributionCenterResponse> Handle(DistributionCenterByCodeQuery query, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<List<DistributionCenter>>(_mediator.Send(query));

        return _mapper.Map<DistributionCenterResponse>(result.FirstOrDefault());
    }
}