using Wms.Core.Domain.Common.Models;

namespace Wms.Core.Domain.Owner.ValueObjects;

public class CustomerId : ValueObject
{
    public Guid Value { get; }

    private CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId Create()
    {
        return new CustomerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}