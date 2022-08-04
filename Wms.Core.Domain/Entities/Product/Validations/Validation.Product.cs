using ErrorOr;

namespace Wms.Core.Domain.Entities.Product.Validations;

public static partial class Validation
{
    public static class Product
    {
        public static Error CodeWasNotInformed = Error.Validation(
            code: "Product.CodeWasNotInformed",
            description: "O código do produto nao foi informado!");

        public static Error OwnerWasNotInformed = Error.Validation(
            code: "Product.OwnerWasNotInformed",
            description: "O proprietário nao foi informado");
    }
}