using System.Linq.Expressions;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.UnitizerTypeUseCases.Contracts;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.UnitizerTypeUseCases.Queries;

public class UnitizerTypeQueryHandler : ICommandHandler<UnitizerTypeQuery, List<UnitizerTypeResponse>>
{
    private readonly IUnitizerTypeRepository _repository;

    public UnitizerTypeQueryHandler(IUnitizerTypeRepository repository)
    {
        _repository = repository;
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

        var response = await _repository.Get(expression);

        List<UnitizerTypeResponse> responses = new();

        response
            .ToList()
            .ForEach(u => responses.Add(
                new UnitizerTypeResponse(
                    u.Id, 
                    u.Code, 
                    u.Description, 
                    u.MaximumWeight, 
                    u.WeightUnit, 
                    u.Height, 
                    u.HeightUnit, 
                    u.Width, 
                    u.WidthUnit, 
                    u.Length, 
                    u.LengthUnit, 
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(u.CreationDate).ToLocalTime().ToString(), 
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(u.LastChangeDate).ToLocalTime().ToString())));

        return responses;
    }
}