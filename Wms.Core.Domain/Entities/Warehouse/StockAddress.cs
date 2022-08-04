using Wms.Core.Domain.Entities.Warehouse.Abstractions;

namespace Wms.Core.Domain.Entities.Warehouse;

public record StockAddress : GenericAddress
{
    public int Id { get; set; }
    public int OccupationStatus { get; set; }
    public int OccupancyPercentage { get; set; }
    public string? BarCode { get; set; }
    public string? FirstComponent { get; set; }
    public string? SecondComponent { get; set; }
    public string? ThirdComponent { get; set; }
    public string? FourthComponent { get; set; }
    public string? FifthComponent { get; set; }
    public string? SixthComponent { get; set; }
    public bool SingleProduct { get; set; }
    public bool SingleBatch { get; set; }
    public bool FixedPicking { get; set; }
    public float MinimumAmount { get; set; }
    public float MaximumAmount { get; set; }

    /*Ef constraints*/
    public string? OwnerCode { get; set; }
    public string? ProductCode { get; set; }
    public string? TypeAddress { get; set; }

}