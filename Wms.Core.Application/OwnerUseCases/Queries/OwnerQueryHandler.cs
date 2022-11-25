using System.Linq.Expressions;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

namespace Wms.Core.Application.OwnerUseCases.Queries;

public class OwnerQueryHandler : ICommandHandler<OwnerQuery, IEnumerable<OwnerResponse>>
{
    private readonly IOwnerRepository _repository;

    public OwnerQueryHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OwnerResponse>> Handle(OwnerQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Expression<Func<Owner, bool>> expression = e =>
            (e.Code == request.Code || request.Code == null) &&
            (e.Document == request.Document || request.Document == null) &&
            (e.Id == request.Id || request.Id == null);

        IEnumerable<Owner>? owners = _repository.Get(expression);

        return OwnerResponse.Create(owners!);
    }
}