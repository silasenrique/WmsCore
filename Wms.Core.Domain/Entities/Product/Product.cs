using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Product;

public class Product
{
    public Product(string? ownerCode, string? code)
    {
        OwnerCode = ownerCode;
        Code = code;
    }

    public Product(string? ownerCode, string? code, string? description, GlobalStatus status)
    {
        OwnerCode = ownerCode;
        Code = code;
        Description = description;
        Status = status;

        CreationDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        LastChangeDate = CreationDate;
    }

    public Product(int id, string? ownerCode, string? code, string? description, GlobalStatus status)
    {
        Id = id;
        OwnerCode = ownerCode;
        Code = code;
        Description = description;
        Status = status;

        LastChangeDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }

    public int Id { get; set; }
    public string? OwnerCode { get; set; }  // Ef constraints
    public string? Code { get; set; }
    public string? Description { get; set; }
    public GlobalStatus Status { get; set; }
    public long CreationDate { get; set; }
    public long LastChangeDate { get; set; }
}
