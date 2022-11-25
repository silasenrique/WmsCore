using Wms.Core.Domain.Common.Models;

namespace Wms.Core.Domain.Owner.ValueObjects;

public class ShippingCompanyId : ValueObject
{
    public Guid Value { get; }

    private ShippingCompanyId(Guid value)
    {
        Value = value;
    }

    public static ShippingCompanyId Create()
    {
        return new ShippingCompanyId(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
       yield return Value;
    }
}