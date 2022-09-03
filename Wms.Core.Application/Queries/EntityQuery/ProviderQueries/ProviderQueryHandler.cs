using System.Linq.Expressions;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.Provider;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Queries.EntityQuery.ProviderQueries;

public class ProviderQueryHandler : ICommandHandler<ProviderQuery, List<ProviderResponse>?>
{
    readonly IProviderRepository _repository;
    readonly IMapper _mapper;

    public ProviderQueryHandler(IProviderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProviderResponse>?> Handle(ProviderQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Provider, bool>> expression = e =>
         (e.Code == query.Code || query.Code == null) &&
         (e.Document == query.Document || query.Document == null) &&
         (e.Id == query.Id || query.Id == 0) &&
         (e.Name.Contains(query.Name) || query.Name == null);

        return _mapper.Map<List<ProviderResponse>>(await _repository.Get(expression));
    }
}