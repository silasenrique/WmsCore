using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Product;

public class Product
{
    public Product(string ownerCode, string code)
    {
        OwnerCode = ownerCode;
        Code = code;
    }

    public Product(string ownerCode, string code, string description, GlobalStatus status)
    {
        OwnerCode = ownerCode;
        Code = code;
        Description = description;
        Status = status;

        CreationDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        LastChangeDate = CreationDate;
    }

    public Product(int id, string ownerCode, string code, string description, GlobalStatus status)
    {
        Id = id;
        OwnerCode = ownerCode;
        Code = code;
        Description = description;
        Status = status;

        LastChangeDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }

    public int Id { get; set; }
    public string OwnerCode { get; private set; }  // Ef constraints
    public string Code { get; private set; }
    public string Description { get; private set; }
    public GlobalStatus Status { get; private set; }
    public long CreationDate { get; private set; }
    public long LastChangeDate { get; private set; }
}
