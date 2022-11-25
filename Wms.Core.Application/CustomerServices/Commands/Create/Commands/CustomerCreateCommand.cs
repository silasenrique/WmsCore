namespace Wms.Core.Application.CustomerServices.Commands.Create;

public record CustomerCreateCommand(
    string Code,
    string Name,
    string Document
);