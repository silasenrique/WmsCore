using System.Linq.Expressions;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ShippingUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ShippingUseCases.Queries;

public class ShippingQueryHandler : ICommandHandler<ShippingQuery, List<ShippingResponse>?>
{
    readonly IShippingRepository _repository;

    public ShippingQueryHandler(IShippingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ShippingResponse>?> Handle(ShippingQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Shipping, bool>> expression = e =>
            (e.Code == query.Code || query.Code == null) &&
            (e.Document == query.Document || query.Document == null) &&
            (e.Id == query.Id || query.Id == null) &&
            (e.Name.Contains(query.Name) || query.Name == null);

        List<ShippingResponse> response = new();
        IEnumerable<Shipping> result = await _repository.Get(expression);
        if (!result.Any()) return response;
        
        response.AddRange(result.Select(sh => new ShippingResponse(
            sh.Id,
            sh.Code,
            sh.Document,
            sh.Name,
            sh.TypeDoc,
            sh.Status,
            sh.CreationDate, 
            sh.LastChangeDate)));

        return response;
    }
}