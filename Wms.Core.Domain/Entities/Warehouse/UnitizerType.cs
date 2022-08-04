using ErrorOr;
using Wms.Core.Domain.Entities.Warehouse.Validations;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Warehouse;

public record UnitizerType
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

    public List<Error> Validate()
    {
        List<Error?> checkErrors = new();
        List<Error> validationErrors = new();

        checkErrors.Add(IsWidthGreaterThanLength());
        checkErrors.Add(HaveAllDimensionsBeenReported());
        checkErrors.Add(IsCodeNull());
        AreTheMeasurementUnitsNegative().ForEach(error => checkErrors.Add(error));
        WereTheUnitsInformed().ForEach(error => checkErrors.Add(error));
        HaveTheUnitValuesBeenReported().ForEach(error => checkErrors.Add(error));

        checkErrors.RemoveAll(error => error == null);
        checkErrors.ForEach(error => validationErrors.Add((Error)error!));

        return validationErrors;
    }

    Error? IsCodeNull()
    {
        if (Code?.Length == 0)
        {
            return Validation.UnitizerType.CodeIsNull;
        }

        return null;
    }

    Error? IsWidthGreaterThanLength()
    {
        if (WidthUnit > LengthUnit && Width > Length)
        {
            return Validation.UnitizerType.WidthIsGreaterThanLength;
        }

        return null;
    }

    Error? HaveAllDimensionsBeenReported()
    {
        if (Width == 0 && Length == 0 && Height == 0)
        {
            return null;
        }

        if (Width == 0 || Length == 0 || Height == 0)
        {
            return Validation.UnitizerType.NotAllDimensionsProvided;
        }

        return null;
    }

    List<Error> AreTheMeasurementUnitsNegative()
    {
        List<Error> errors = new();

        if (MaximumWeight < 0)
        {
            errors.Add(Validation.UnitizerType.WeightNegative);
        }

        if (Width < 0)
        {
            errors.Add(Validation.UnitizerType.WidthNegative);
        }

        if (Length < 0)
        {
            errors.Add(Validation.UnitizerType.LengthNegative);
        }

        if (Height < 0)
        {
            errors.Add(Validation.UnitizerType.HeightNegative);
        }

        return errors;
    }

    List<Error> WereTheUnitsInformed()
    {
        List<Error> errors = new();

        if (Height > 0 && HeightUnit == 0)
        {
            errors.Add(Validation.UnitizerType.HeightWithoutUnitOfMeasure);
        }

        if (Width > 0 && WidthUnit == 0)
        {
            errors.Add(Validation.UnitizerType.WidthWithoutUnitOfMeasure);
        }

        if (Length > 0 && LengthUnit == 0)
        {
            errors.Add(Validation.UnitizerType.LengthWithoutUnitOfMeasure);
        }

        if (MaximumWeight > 0 && WeightUnit == 0)
        {
            errors.Add(Validation.UnitizerType.WeightWithoutUnitOfMeasure);
        }

        return errors;
    }

    List<Error> HaveTheUnitValuesBeenReported()
    {
        List<Error> errors = new();

        if (Height == 0 && HeightUnit != 0)
        {
            errors.Add(Validation.UnitizerType.HeightWithoutValue);
        }

        if (Width == 0 && WidthUnit != 0)
        {
            errors.Add(Validation.UnitizerType.WidthWithoutValue);
        }

        if (Length == 0 && LengthUnit != 0)
        {
            errors.Add(Validation.UnitizerType.LengthWithoutValue);
        }

        if (MaximumWeight == 0 && WeightUnit != 0)
        {
            errors.Add(Validation.UnitizerType.WeightWithoutValue);
        }

        return errors;
    }
}