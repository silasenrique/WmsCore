using ErrorOr;

namespace Wms.Core.Application.Services.Errors;

public static partial class Errors
{
    public static class Shipping
    {
        public static Error AlreadyExist => Error.Validation(
            code: "Shipping.AlreadyExist",
            description: "O código do transportador ja existe!");
    }
}