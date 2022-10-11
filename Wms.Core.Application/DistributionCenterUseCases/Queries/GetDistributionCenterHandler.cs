using System.Linq.Expressions;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Queries;

public class GetDistributionCenterHandler : ICommandHandler<DistributionCenterUseCases.Queries.DistributionCenterQueries, List<DistributionCenterResponse>>
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
        (e.Id == query.Id || query.Id == 0) &&
        (e.Code == query.Code || query.Code == null) &&
        (e.Document == query.Document || query.Document == null) &&
        (e.Name.Contains(query.Name) || query.Name == null);

        return _mapper.Map<List<DistributionCenterResponse>>(await _repository.Get(expression));
    }
}