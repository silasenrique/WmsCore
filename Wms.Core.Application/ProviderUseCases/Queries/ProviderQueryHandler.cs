using System.Linq.Expressions;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProviderUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ProviderUseCases.Queries;

public class ProviderQueryHandler : ICommandHandler<ProviderQuery, List<ProviderResponse>?>
{
    readonly IProviderRepository _repository;

    public ProviderQueryHandler(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProviderResponse>?> Handle(ProviderQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Provider, bool>> expression = e =>
            (e.Code == query.Code || query.Code == null) &&
            (e.Document == query.Document || query.Document == null) &&
            (e.Id == query.Id || query.Id == null) &&
            (e.Name.Contains(query.Name) || query.Name == null);

        List<ProviderResponse> response = new();
        IEnumerable<Provider> result = await _repository.Get(expression);
        if (!result.Any()) return response;
        
        response.AddRange(result.Select(pv => new ProviderResponse(
            pv.Id,
            pv.Code,
            pv.Document,
            pv.Name,
            pv.TypeDoc,
            pv.Status,
            pv.CreationDate,
            pv.LastChangeDate)));

        return response;
    }
}