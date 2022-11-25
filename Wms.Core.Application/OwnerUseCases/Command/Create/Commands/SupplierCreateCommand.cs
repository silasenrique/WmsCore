namespace Wms.Core.Application.OwnerUseCases.Command.Create.Commands;

public record SupplierCreateCommand(
    string Code,
    string Name,
    string Document
);
