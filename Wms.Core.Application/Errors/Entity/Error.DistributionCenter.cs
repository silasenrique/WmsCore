using ErrorOr;

namespace Wms.Core.Application.Errors.EntityErrors;

public static partial class EntityErrors
{
    public static class DistributionCenter
    {
        public static Error CodeHasBeenEnteredBefore = Error.Conflict(
           code: "CodeHasBeenEnteredBefore",
           description: "O código ou o documento já foram informados anteriormente!");

        public static Error IdIsNecessary = Error.Conflict(
        code: "IdIsNecessary",
        description: "é necessário informar o id");
    }
}