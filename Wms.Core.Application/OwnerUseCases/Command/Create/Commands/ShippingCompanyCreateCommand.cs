namespace Wms.Core.Application.OwnerUseCases.Command.Create.Commands;

public record ShippingCompanyCreateCommand(
    string Code,
    string Name,
    string Document
);
