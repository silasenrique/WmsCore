using Wms.Core.Domain.Common.Models;

namespace Wms.Core.Domain.Owner.ValueObjects;

public class SupplierId : ValueObject
{
    public Guid Value { get; }

    private SupplierId(Guid value)
    {
        Value = value;
    }

    public static SupplierId Create()
    {
        return new SupplierId(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
       yield return Value;
    }
}