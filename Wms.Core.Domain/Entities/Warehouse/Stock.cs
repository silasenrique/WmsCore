using Wms.Core.Domain.Entities.Warehouse.Abstractions;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Warehouse;

public record Stock : GenericAddress
{
    public int Id { get; set; }
    public string? Lot { get; set; }
    public string? ExpirationDate { get; set; }
    public string? ProductionDate { get; set; }
    public bool Blocked { get; set; }
    public bool InMotion { get; set; }
    public StockBlockingReason BlockingReason { get; set; }
    public decimal AvailableQuantity { get; set; }
    public decimal ReservedQuantity { get; set; }
    public decimal QuantityInCirculation { get; set; }

    /*Ef constraints*/
    public string? OwnerCode { get; set; }
    public string? ProductCode { get; set; }
    public int NrUnitizer { get; set; }
}