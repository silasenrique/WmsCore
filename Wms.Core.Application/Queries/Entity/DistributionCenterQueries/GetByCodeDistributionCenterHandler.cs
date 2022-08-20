using System.Linq.Expressions;
using MapsterMapper;
using MediatR;
using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Queries.Entity.DistributionCenterQueries;

public class GetByCodeDistributionCenter : ICommandHandler<DistributionCenterByCodeQuery, DistributionCenterResponse>
{
    readonly IMapper _mapper;
    readonly IDistributionCenterRepository _repository;

    public GetByCodeDistributionCenter(IMapper mapper, IDistributionCenterRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DistributionCenterResponse> Handle(DistributionCenterByCodeQuery query, CancellationToken cancellationToken)
    {

        Expression<Func<DistributionCenter, bool>> expression = ex => ex.Code == query.Code;

        var result = await _repository.Get(expression);

        return _mapper.Map<DistributionCenterResponse>(result.FirstOrDefault());
    }
}