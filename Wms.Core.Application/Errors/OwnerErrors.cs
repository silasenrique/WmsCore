using ErrorOr;

namespace Wms.Core.Application.ApplicationErrors;

public static class OwnerErros
{
    public static Error CodeHasBeenEnteredBefore = Error.Conflict(
       code: "CodeHasBeenEnteredBefore",
       description: "O código ou o documento já foram informados anteriormente!");

}