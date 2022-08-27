using ErrorOr;

namespace Wms.Core.Application.ApplicationErrors;

public static class DistributionCenterErrors
{

    public static Error CodeHasBeenEnteredBefore = Error.Conflict(
       code: "CodeHasBeenEnteredBefore",
       description: "O código já foi informados anteriormente!");

    public static Error IdIsNecessary = Error.Conflict(
        code: "IdIsNecessary",
        description: "é necessário informar o id");

    public static Error DocumentHasBenEnteredBefore = Error.Conflict(
       code: "DocumentHasBenEnteredBefore",
       description: "O documento já foi informado anteriormente!");

}