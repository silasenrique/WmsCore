using ErrorOr;
using Wms.Core.Domain.Entities.Product.Validations;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Product;

public class Product
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public GlobalStatus Status { get; set; }

    /*Ef constraints*/
    public string? OwnerCode { get; set; }

    public List<Error> Validate()
    {
        List<Error?> errors = new();
        List<Error> validations = new();

        errors.Add(IsTheCodeNull());
        errors.Add(IsOwnerNull());

        errors.RemoveAll(error => error == null);
        errors.ForEach(error => validations.Add((Error)error!));

        return validations;
    }

    Error? IsTheCodeNull()
    {
        if (Code?.Length == 0)
        {
            return Validation.Product.CodeWasNotInformed;
        }

        return null;
    }

    Error? IsOwnerNull()
    {
        if (OwnerCode?.Length == 0)
        {
            return Validation.Product.OwnerWasNotInformed;
        }

        return null;
    }
}
