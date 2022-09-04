using Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Create;

public record UnitizerTypeCreateCommand : UnitizerTypeCommonWriteCommand
{
    public UnitizerTypeCreateCommand(
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
    }
}