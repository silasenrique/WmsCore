using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Unitizer;

public class UnitizerType
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public float MaximumWeight { get; set; }
    public WeightUnit WeightUnit { get; set; }
    public float Height { get; set; }
    public SizeUnit HeightUnit { get; set; }
    public float Width { get; set; }
    public SizeUnit WidthUnit { get; set; }
    public float Length { get; set; }
    public SizeUnit LengthUnit { get; set; }
}