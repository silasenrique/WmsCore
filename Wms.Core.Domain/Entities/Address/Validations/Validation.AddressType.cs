using ErrorOr;

namespace Wms.Core.Domain.Entities.Address.Validations;

public static partial class Validation
{
    public static class AddressType
    {
        public static Error CdIsNull = Error.Validation(
            code: "Unitizer.CdIsNull",
            description: "O código do centro de distribuição não foi informado!"
        );

        public static Error WidthIsGreaterThanLength = Error.Validation(
            code: "Unitizer.WidthIsGreaterThanLength",
            description: "A largura não pode ser maior que o comprimento!"
        );

        public static Error CodeIsNull = Error.Validation(
            code: "Unitizer.CodeIsNull",
            description: "O código não foi informado!"
        );

        public static Error NotAllDimensionsProvided = Error.Conflict(
            code: "Unitizer.NotAllDimensionsProvided",
            description: "Se uma dimensão foi informada, todas as outras também devem ser informadas!"
        );

        public static Error WeightNegative = Error.Validation(
            code: "Unitizer.WeightNegative",
            description: "O peso não pode ser negativo!"
        );

        public static Error HeightNegative = Error.Validation(
            code: "Unitizer.HeightNegative",
            description: "A altura não pode ser negativa!"
        );

        public static Error LengthNegative = Error.Validation(
            code: "Unitizer.LengthNegative",
            description: "O comprimento não pode ser negativo!"
        );

        public static Error WidthNegative = Error.Validation(
            code: "Unitizer.WidthNegative",
            description: "A largura não pode ser negativa!"
        );

        public static Error HeightWithoutUnitOfMeasure = Error.Validation(
           code: "Unitizer.HeightWithoutUnitOfMeasure",
           description: "É necessário informar qual é a unidade de medida da altura"
       );

        public static Error LengthWithoutUnitOfMeasure = Error.Validation(
            code: "Unitizer.LengthWithoutUnitOfMeasure",
            description: "É necessário informar qual é a unidade de medida do comprimento"
        );

        public static Error WidthWithoutUnitOfMeasure = Error.Validation(
           code: "Unitizer.WidthWithoutUnitOfMeasure",
           description: "É necessário informar qual é a unidade de medida da largura"
       );

        public static Error WeightWithoutUnitOfMeasure = Error.Validation(
            code: "Unitizer.WeightWithoutUnitOfMeasure",
            description: "É necessário informar qual é a unidade de medida do peso"
        );

        public static Error HeightWithoutValue = Error.Validation(
           code: "Unitizer.HeightWithoutValue",
           description: "É necessário informar qual é o tamanho da altura!"
       );

        public static Error LengthWithoutValue = Error.Validation(
            code: "Unitizer.LengthWithoutValue",
            description: "É necessário informar qual é o tamanho do comprimento!"
        );

        public static Error WidthWithoutValue = Error.Validation(
           code: "Unitizer.WidthWithoutValue",
           description: "É necessário informar qual é o tamanho da largura!"
       );

        public static Error WeightWithoutValue = Error.Validation(
            code: "Unitizer.WeightWithoutValue",
            description: "É necessário informar qual é o peso!"
        );
    }
}