using System.Linq.Expressions;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.Shipping;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Queries.EntityQuery.ShippingQueries;

public class ShippingQueryHandler : ICommandHandler<ShippingQuery, List<ShippingResponse>?>
{
    readonly IShippingRepository _repository;
    readonly IMapper _mapper;

    public ShippingQueryHandler(IShippingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ShippingResponse>?> Handle(ShippingQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Shipping, bool>> expression = e =>
         (e.Code == query.Code || query.Code == null) &&
         (e.Document == query.Document || query.Document == null) &&
         (e.Id == query.Id || query.Id == 0) &&
         (e.Name.Contains(query.Name) || query.Name == null);

        return _mapper.Map<List<ShippingResponse>>(await _repository.Get(expression));
    }
}