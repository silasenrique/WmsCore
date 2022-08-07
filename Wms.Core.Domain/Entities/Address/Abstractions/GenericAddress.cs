using ErrorOr;
using Wms.Core.Domain.Entities.Address.Abstractions.Validations;

namespace Wms.Core.Domain.Entities.Address.Abstractions;

public abstract class GenericAddress
{
    public string? Cd { get; set; }
    public string? Deposit { get; set; }
    public string? Area { get; set; }
    public string? Address { get; set; }

    public List<Error> Validate()
    {
        List<Error?> checkErrors = new();
        List<Error> validationErrors = new();

        checkErrors.Add(CdIsNull());
        checkErrors.Add(DepositIsNull());
        checkErrors.Add(AreaIsNull());
        checkErrors.Add(AddressIsNull());

        return validationErrors;
    }

    Error? AddressIsNull()
    {
        if (Address == null)
        {
            return Validation.GenericAddress.AddressIsNull;
        }

        return null;
    }

    Error? AreaIsNull()
    {
        if (Area == null)
        {
            return Validation.GenericAddress.AreaIsNull;
        }

        return null;
    }

    Error? DepositIsNull()
    {
        if (Deposit == null)
        {
            return Validation.GenericAddress.DepositIsNull;
        }

        return null;
    }

    Error? CdIsNull()
    {
        if (Cd == null)
        {
            return Validation.GenericAddress.CdIsNull;
        }

        return null;
    }
}