using System.Linq.Expressions;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Queries;

public class OwnerQueryHandler : ICommandHandler<OwnerQuery, List<OwnerResponse>>
{
    private readonly IOwnerRepository _repository;

    public OwnerQueryHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<OwnerResponse>> Handle(OwnerQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Owner, bool>> expression = e =>
            (e.Code == query.Code || query.Code == null) &&
            (e.Document == query.Document || query.Document == null) &&
            (e.Id == query.Id || query.Id == null) &&
            (e.Name.Contains(query.Name) || query.Name == null);

        List<OwnerResponse> response = new();
        IEnumerable<Owner> result = await _repository.Get(expression);
        if (!result.Any()) return response;
        
        response.AddRange(result.Select(ow => new OwnerResponse(
                ow.Id,
                ow.Code,
                ow.Document,
                ow.Name,
                ow.TypeDoc,
                ow.Status,
                new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(ow.CreationDate).ToLocalTime().ToString(), 
                new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(ow.LastChangeDate).ToLocalTime().ToString())));

        return response;
    }
}