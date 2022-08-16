using System.Linq.Expressions;
using MapsterMapper;
using MediatR;
using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Queries.Entity.DistributionCenterQueries;

public class GetDistributionCenterHandler : ICommandHandler<DistributionCenterQueries, List<DistributionCenterResponse>>
{
    readonly IDistributionCenterRepository _repository;
    readonly IMapper _mapper;

    public GetDistributionCenterHandler(IDistributionCenterRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<DistributionCenterResponse>> Handle(DistributionCenterQueries query, CancellationToken cancellationToken)
    {
        Expression<Func<DistributionCenter, bool>> expression = e =>
        // (e.Id == query.Id || query.Id == 0) &&
        (e.Code == query.Code || query.Code == null) &&
        (e.Document == query.Document || query.Document == null)/* &&
        (e.Name.Contains(query.Name) || query.Name == null)*/;

        return _mapper.Map<List<DistributionCenterResponse>>(await _repository.Get(expression));
    }
}