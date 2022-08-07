using Wms.Core.Domain.Entities.Address.Abstractions;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Unitizer;

public class Unitizer : GenericAddress
{
    public int Id { get; set; }
    public int NrUnitizer { get; set; }
    public bool InMotion { get; set; }
    public UnitizerCapacityStatus Status { get; set; }

    /*Ef constraints*/
    public string? UnitizerType { get; set; }
}