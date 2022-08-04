namespace Wms.Core.Domain.Entities.Product;

public record ProductControl
{
    public int Id { get; set; }
    public bool Lot { get; set; }
    public bool ExpirationDate { get; set; }
    public bool ProductionDate { get; set; }

    /*Ef constraints*/
    public string? Cd { get; set; }
    public string? DriveUnit { get; set; }
    public string? OwnerCode { get; set; }
    public string? ProductCode { get; set; }
}