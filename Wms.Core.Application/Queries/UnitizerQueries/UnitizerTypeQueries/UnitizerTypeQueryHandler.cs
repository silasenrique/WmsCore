using System.Linq.Expressions;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.UnitizerContract;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.Queries.UnitizerQueries.UnitizerTypeQueries;

public class UnitizerTypeQueryHandler : ICommandHandler<UnitizerTypeQuery, List<UnitizerTypeResponse>>
{
    private readonly IUnitizerTypeRepository _repository;
    private readonly IMapper _mapper;

    public UnitizerTypeQueryHandler(IUnitizerTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<UnitizerTypeResponse>> Handle(UnitizerTypeQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<UnitizerType, bool>> expression = e =>
            (e.Code == query.Code || query.Code == null) &&
            (e.Id == query.Id || query.Id == 0) &&
            (e.WidthUnit == query.WidthUnit || query.WidthUnit == 0) &&
            (e.HeightUnit == query.HeightUnit || query.HeightUnit == 0) &&
            (e.LengthUnit == query.LengthUnit || query.LengthUnit == 0) &&
            (e.WeightUnit == query.WeightUnit || query.WeightUnit == 0);

        return _mapper.Map<List<UnitizerTypeResponse>>(await _repository.Get(expression));
    }
}