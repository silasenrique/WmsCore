namespace Wms.Core.Application.Contracts.Product.ProductContract;

public record ProductResponse(
    int Id,
    string? Code,
    string? Description,
    int Status,
    string? OwnerCode,
    string? CreationDate,
    string? LastChangeDate
);