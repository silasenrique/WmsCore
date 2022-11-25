using Wms.Core.Domain.Common.Models;

namespace Wms.Core.Domain.DistributionCenter.ValueObjects;

public sealed class DistributionCenterId : ValueObject
{
    private DistributionCenterId(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }

    public static DistributionCenterId Create()
    {
        return new DistributionCenterId(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}