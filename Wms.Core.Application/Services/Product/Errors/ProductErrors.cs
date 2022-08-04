using ErrorOr;

namespace Wms.Core.Application.ApplicationErrors;

public static partial class Errors
{
    public static class Product
    {
        public static Error AlreadyExist => Error.Conflict(
            code: "Product.AlreadyExist",
            description: "Codigo do produto ja foi informado anteriormente!");

        public static Error NotExist => Error.NotFound(
            code: "Product.NotExist",
            description: "O produto nao exite!");
    }
}