using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Unitizer;

public record UnitizerType
{
    public UnitizerType(string code)
    {
        Code = code;
    }

    public UnitizerType(
        string code,
        string description,
        float maximumWeight,
        WeightUnit weightUnit,
        float height,
        SizeUnit heightUnit,
        float width,
        SizeUnit widthUnit,
        float length,
        SizeUnit lengthUnit) : this(code)
    {
        Description = description;
        MaximumWeight = maximumWeight;
        WeightUnit = weightUnit;
        Height = height;
        HeightUnit = heightUnit;
        Width = width;
        WidthUnit = widthUnit;
        Length = length;
        LengthUnit = lengthUnit;
    }

    public UnitizerType(
        int id,
        string code,
        string description,
        float maximumWeight,
        WeightUnit weightUnit,
        float height,
        SizeUnit heightUnit,
        float width,
        SizeUnit widthUnit,
        float length,
        SizeUnit lengthUnit)
    {
        Id = id;
        Code = code;
        Description = description;
        MaximumWeight = maximumWeight;
        WeightUnit = weightUnit;
        Height = height;
        HeightUnit = heightUnit;
        Width = width;
        WidthUnit = widthUnit;
        Length = length;
        LengthUnit = lengthUnit;
    }

    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public float MaximumWeight { get; set; }
    public WeightUnit WeightUnit { get; set; }
    public float Height { get; set; }
    public SizeUnit HeightUnit { get; set; }
    public float Width { get; set; }
    public SizeUnit WidthUnit { get; set; }
    public float Length { get; set; }
    public SizeUnit LengthUnit { get; set; }
    public long CreationDate { get; set; }
    public long LastChangeDate { get; set; }
}