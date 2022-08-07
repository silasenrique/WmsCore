using ErrorOr;

namespace Wms.Core.Domain.Entities.Address.Validations;

public static partial class Validation
{
    public static class Zone
    {
        public static Error CdIsNull = Error.Validation(
            code: "Unitizer.CdIsNull",
            description: "O código do centro de distribuição deve ser informado!"
        );

        public static Error AreaIsNull = Error.Validation(
           code: "Unitizer.AreaIsNull",
           description: "A área não pode ser nula!"
        );

        public static Error DepositIsNull = Error.Validation(
            code: "Unitizer.DepositIsNull",
            description: "O depósito não pode ser nulo!"
        );

        public static Error FirstComponentIsNull = Error.Validation(
            code: "Unitizer.FirstComponentIsNull",
            description: "O primeiro componente está nulo!"
        );
    }
}