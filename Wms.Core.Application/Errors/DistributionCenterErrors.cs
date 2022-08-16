using ErrorOr;

namespace Wms.Core.Application.ApplicationErrors;

public static class DistributionCenterErrors
{

    public static Error CodeHasBeenEnteredBefore = Error.Conflict(
       code: "CodeHasBeenEnteredBefore",
       description: "O código ou o documento já foram informados anteriormente!");

    public static Error IdIsNecessary = Error.Conflict(
        code: "IdIsNecessary",
        description: "é necessário informar o id");

}