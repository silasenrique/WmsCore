using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.Contracts.UnitizerContract;

public record UnitizerTypeResponse(
    int Id,
    string Code,
    string Description,
    float MaximumWeight,
    WeightUnit WeightUnit,
    float Height,
    SizeUnit HeightUnit,
    float Width,
    SizeUnit WidthUnit,
    float Length,
    SizeUnit LengthUnit);