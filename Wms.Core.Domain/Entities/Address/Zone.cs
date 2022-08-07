using ErrorOr;
using Wms.Core.Domain.Enums;
using Wms.Core.Domain.Entities.Address.Validations;

namespace Wms.Core.Domain.Entities.Address;

public class Zone
{
    public int Id { get; set; }
    public string? Deposit { get; set; }
    public string? Area { get; set; }
    public GlobalStatus Status { get; set; }
    public string? FirstComponent { get; set; }
    public string? SecondComponent { get; set; }
    public string? ThirdComponent { get; set; }
    public string? FourthComponent { get; set; }
    public string? FifthComponent { get; set; }
    public string? SixthComponent { get; set; }
    public string? AddressFormat { get; set; }
    public bool Dock { get; set; }
    public bool SingleProduct { get; set; }
    public bool SingleBatch { get; set; }
    public bool FixedPicking { get; set; }
    public bool DynamicReplacement { get; set; }
    public bool MinimumAndMaximumReplacement { get; set; }

    /*Ef entities*/
    public string? Cd { get; set; }
    public string? TypeAddressCode { get; set; }

    public List<Error> Validate()
    {
        List<Error?> checkErrors = new();
        List<Error> validationErrors = new();

        checkErrors.Add(FistComponentIsNull());
        checkErrors.Add(DepositIsNull());
        checkErrors.Add(AreaIsNull());
        checkErrors.Add(CdIsNull());

        checkErrors.RemoveAll(error => error == null);
        checkErrors.ForEach(error => validationErrors.Add((Error)error!));

        return validationErrors;
    }

    Error? FistComponentIsNull()
    {
        if (FirstComponent?.Length == 0)
        {
            return Validation.Zone.FirstComponentIsNull;
        }

        return null;
    }

    Error? DepositIsNull()
    {
        if (Deposit?.Length == 0)
        {
            return Validation.Zone.DepositIsNull;
        }

        return null;
    }

    Error? AreaIsNull()
    {
        if (Area?.Length == 0)
        {
            return Validation.Zone.AreaIsNull;
        }

        return null;
    }

    Error? CdIsNull()
    {
        if (Cd?.Length == 0)
        {
            return Validation.Zone.CdIsNull;
        }

        return null;
    }
}