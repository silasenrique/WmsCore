using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Product;

public class ProductPackaging
{
    public int Id { get; set; }
    public string? BarCode { get; set; }
    public float Quantity { get; set; }
    public float MaximumWeight { get; set; }
    public WeightUnit WeightUnit { get; set; }
    public float Height { get; set; }
    public SizeUnit HeightUnit { get; set; }
    public float Width { get; set; }
    public SizeUnit WidthUnit { get; set; }
    public float Length { get; set; }
    public SizeUnit LengthUnit { get; set; }

    //* FK Constraints
    public string? Cd { get; set; }
    public string? OwnerCode { get; set; }
    public string? ProductCode { get; set; }
    public string? UnitizerType { get; set; }
}