using ErrorOr;

namespace Wms.Core.Application.Services.Errors;

public static partial class Errors
{
    public static class DistributionCenter
    {
        public static Error AlreadyExist => Error.Validation(
            code: "Owner.AlreadyExist",
            description: "O código do centro de distribuição ja existe!");
    }
}