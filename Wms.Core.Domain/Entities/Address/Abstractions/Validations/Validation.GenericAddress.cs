using ErrorOr;

namespace Wms.Core.Domain.Entities.Address.Abstractions.Validations;

public static partial class Validation
{
    public static class GenericAddress
    {
        public static Error CdIsNull = Error.Validation(
            code: "Address.CdIsNull",
            description: "O código do centro de distribuição deve ser informado!"
        );

        public static Error AreaIsNull = Error.Validation(
           code: "Address.AreaIsNull",
           description: "A área não pode ser nula!"
        );

        public static Error DepositIsNull = Error.Validation(
            code: "Address.DepositIsNull",
            description: "O depósito não pode ser nulo!"
        );

        public static Error AddressIsNull = Error.Validation(
            code: "Address.AddressIsNull",
            description: "O endereço não pode ser nulo!"
        );
    }
}