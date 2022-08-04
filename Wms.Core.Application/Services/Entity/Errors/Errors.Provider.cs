using ErrorOr;

namespace Wms.Core.Application.Services.Errors;

public static partial class Errors
{
    public static class Provider
    {
        public static Error AlreadyExist => Error.Validation(
            code: "Provider.AlreadyExist",
            description: "O código do fornecedor ja existe!");
    }
}