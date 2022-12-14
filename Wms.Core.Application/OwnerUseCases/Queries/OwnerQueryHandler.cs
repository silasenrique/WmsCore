using System.Linq.Expressions;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.OwnerUseCases.Queries;

public class OwnerQueryHandler : ICommandHandler<OwnerQuery, List<OwnerResponse>>
{
    private readonly IMapper _mapper;
    private readonly IOwnerRepository _repository;

    public OwnerQueryHandler(IOwnerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<OwnerResponse>> Handle(OwnerQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Owner, bool>> expression = e =>
            (e.Code == query.Code || query.Code == null) &&
            (e.Document == query.Document || query.Document == null) &&
            (e.Id == query.Id || query.Id == 0) &&
            (e.Name.Contains(query.Name) || query.Name == null);

        return _mapper.Map<List<OwnerResponse>>(await _repository.Get(expression));
    }
}