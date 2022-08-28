using ErrorOr;

namespace Wms.Core.Application.Errors.ProductErrors;

public static class ProductErrors
{
    public static Error AlreadyExistsForTheOwner = Error.Conflict(
       code: "DocumentHasBeenEnteredBefore",
       description: "já existe um produto com esse código vinculado ao owner"
   );
}