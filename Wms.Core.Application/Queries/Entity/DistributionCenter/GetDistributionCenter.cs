using System.Linq.Expressions;
using MediatR;
using Wms.Core.Application.DTOs;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Queries.Entity.DistributionCenterQueries;

public class GetDistributionCenter : IRequestHandler<DistributionCenterDTO, List<DistributionCenterDTO>>
{
    readonly IDistributionCenterRepository _repository;

    public GetDistributionCenter(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DistributionCenterDTO>> Handle(DistributionCenterDTO query, CancellationToken cancellationToken)
    {
        Expression<Func<DistributionCenter, bool>> expression = e =>
        (e.Id == query.Id || query.Id == 0) &&
        (e.Code == query.Code || query.Code == null) &&
        (e.Document == query.Document || query.Document == null) &&
        (e.Name.Contains(query.Name) || query.Name == null);

        return await _repository.Get(expression);
    }
}