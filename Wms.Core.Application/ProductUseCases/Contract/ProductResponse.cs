namespace Wms.Core.Application.ProductUseCases.Contract;

public record ProductResponse(
    int Id,
    string? Code,
    string? Description,
    int Status,
    string? OwnerCode,
    string? CreationDate,
    string? LastChangeDate
);