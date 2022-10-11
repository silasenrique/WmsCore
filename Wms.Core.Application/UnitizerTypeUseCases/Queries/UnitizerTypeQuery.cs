using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.UnitizerTypeUseCases.Contracts;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.UnitizerTypeUseCases.Queries;

public record UnitizerTypeQuery(int Id,
                                string? Code,
                                string? Description,
                                float MaximumWeight,
                                WeightUnit WeightUnit,
                                float Height,
                                SizeUnit HeightUnit,
                                float Width,
                                SizeUnit WidthUnit,
                                float Length,
                                SizeUnit LengthUnit) : ICommand<List<UnitizerTypeResponse>>;