using ErrorOr;

namespace Wms.Core.Application.Errors;

public static class ShippingErrors
{
    public static Error CodeHasBeenEnteredBefore = Error.Conflict(
        code: "CodeHasBeenEnteredBefore",
        description: "O código já foi informado anteriormente"
    );

    public static Error DocumentHasBeenEnteredBefore = Error.Conflict(
        code: "DocumentHasBeenEnteredBefore",
        description: "O documento já foi informado anteriormente"
    );
}