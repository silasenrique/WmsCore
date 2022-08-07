using ErrorOr;
using Wms.Core.Domain.Enums;
using Wms.Core.Domain.Entities.Address.Validations;

namespace Wms.Core.Domain.Entities.Warehouse;

public class TypeAddress
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public AddressCapacityType ControlType { get; set; }
    public float Weight { get; set; }
    public WeightUnit WeightUnit { get; set; }
    public float Height { get; set; }
    public SizeUnit HeightUnit { get; set; }
    public float Width { get; set; }
    public SizeUnit WidthUnit { get; set; }
    public float Length { get; set; }
    public SizeUnit LengthUnit { get; set; }

    /*Ef constraints*/
    public string? Cd { get; set; }

    public List<Error> Validate()
    {
        List<Error?> checkErrors = new();
        List<Error> validationErrors = new();

        checkErrors.Add(IsWidthGreaterThanLength());
        checkErrors.Add(HaveAllDimensionsBeenReported());
        checkErrors.Add(IsCodeNull());
        checkErrors.Add(IsCdNull());
        AreTheMeasurementUnitsNegative().ForEach(error => checkErrors.Add(error));
        WereTheUnitsInformed().ForEach(error => checkErrors.Add(error));
        HaveTheUnitValuesBeenReported().ForEach(error => checkErrors.Add(error));

        checkErrors.RemoveAll(error => error == null);
        checkErrors.ForEach(error => validationErrors.Add((Error)error!));

        return validationErrors;
    }

    Error? IsCdNull()
    {
        if (Cd?.Length == 0)
        {
            return Validation.AddressType.CdIsNull;
        }

        return null;
    }

    Error? IsCodeNull()
    {
        if (Code?.Length == 0)
        {
            return Validation.AddressType.CodeIsNull;
        }

        return null;
    }

    Error? IsWidthGreaterThanLength()
    {
        if (WidthUnit > LengthUnit && Width > Length)
        {
            return Validation.AddressType.WidthIsGreaterThanLength;
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
            return Validation.AddressType.NotAllDimensionsProvided;
        }

        return null;
    }

    List<Error> AreTheMeasurementUnitsNegative()
    {
        List<Error> errors = new();

        if (Weight < 0)
        {
            errors.Add(Validation.AddressType.WeightNegative);
        }

        if (Width < 0)
        {
            errors.Add(Validation.AddressType.WidthNegative);
        }

        if (Length < 0)
        {
            errors.Add(Validation.AddressType.LengthNegative);
        }

        if (Height < 0)
        {
            errors.Add(Validation.AddressType.HeightNegative);
        }

        return errors;
    }

    List<Error> WereTheUnitsInformed()
    {
        List<Error> errors = new();

        if (Height > 0 && HeightUnit == 0)
        {
            errors.Add(Validation.AddressType.HeightWithoutUnitOfMeasure);
        }

        if (Width > 0 && WidthUnit == 0)
        {
            errors.Add(Validation.AddressType.WidthWithoutUnitOfMeasure);
        }

        if (Length > 0 && LengthUnit == 0)
        {
            errors.Add(Validation.AddressType.LengthWithoutUnitOfMeasure);
        }

        if (Weight > 0 && WeightUnit == 0)
        {
            errors.Add(Validation.AddressType.WeightWithoutUnitOfMeasure);
        }

        return errors;
    }

    List<Error> HaveTheUnitValuesBeenReported()
    {
        List<Error> errors = new();

        if (Height == 0 && HeightUnit != 0)
        {
            errors.Add(Validation.AddressType.HeightWithoutValue);
        }

        if (Width == 0 && WidthUnit != 0)
        {
            errors.Add(Validation.AddressType.WidthWithoutValue);
        }

        if (Length == 0 && LengthUnit != 0)
        {
            errors.Add(Validation.AddressType.LengthWithoutValue);
        }

        if (Weight == 0 && WeightUnit != 0)
        {
            errors.Add(Validation.AddressType.WeightWithoutValue);
        }

        return errors;
    }
}