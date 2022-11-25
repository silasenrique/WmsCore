namespace Wms.Core.Application.CustomerServices.Contracts;

public record CustomerResponse(
    Guid Id,
    string Code,
    string Name,
    string Document
);