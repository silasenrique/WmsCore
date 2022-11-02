using System.Linq.Expressions;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Queries;

public class GetDistributionCenterHandler : ICommandHandler<DistributionCenterUseCases.Queries.DistributionCenterQueries, List<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _repository;

    public GetDistributionCenterHandler(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DistributionCenterResponse>> Handle(DistributionCenterQueries query, CancellationToken cancellationToken)
    {
        List<DistributionCenterResponse> result = new();
        
        Expression<Func<DistributionCenter, bool>> expression = e =>
            (e.Code == query.Code || query.Code == null) &&
            (e.Document == query.Document || query.Document == null) &&
            (e.Name.Contains(query.Name) || query.Name == null) &&
            (e.Id == query.Id || query.Id == null);

        IEnumerable<DistributionCenter> response = await _repository.Get(expression);
        if (!response.Any()) return result;

        result.AddRange(
            response.Select(cd => new DistributionCenterResponse(
                cd.Id,
                cd.Code,
                cd.Name,
                cd.Document,
                cd.CreationDate, 
                cd.LastChangeDate)));

        return result;
    }
}