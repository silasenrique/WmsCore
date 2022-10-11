using Wms.Core.Application.UnitizerTypeUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.UnitizerTypeUseCases.Commands.Update;

public record UnitizerTypeUpdateCommand : UnitizerTypeCommonWriteCommand
{
    public int Id { get; set; }
    public UnitizerTypeUpdateCommand(
        int id,
        string Code,
        string Description,
        float MaximumWeight,
        WeightUnit WeightUnit,
        float Height,
        SizeUnit HeightUnit,
        float Width,
        SizeUnit WidthUnit,
        float Length,
        SizeUnit LengthUnit) : base(Code, Description, MaximumWeight, WeightUnit, Height, HeightUnit, Width, WidthUnit, Length, LengthUnit)
    {
        Id = id;
    }
}