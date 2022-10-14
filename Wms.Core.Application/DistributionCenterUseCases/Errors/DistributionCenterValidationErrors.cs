using ErrorOr;

namespace Wms.Core.Application.DistributionCenterUseCases.Errors;

public static class DistributionCenterValidationErrors
{
    public static Error CodeIsAlreadyBeingUsed = Error.Conflict(
        code: "code",
        description: "the code is already being used by another entity");
    
    public static Error DocumentIsAlreadyBeingUsed = Error.Conflict(
        code: "document",
        description: "the document is already being used by another entity");
    
    public static Error IdNotFound = Error.Conflict(
        code: "id",
        description: "the given id was not found");
}