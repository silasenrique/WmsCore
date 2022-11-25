using Wms.Core.Domain.Common.Models;

namespace Wms.Core.Domain.Owner.ValueObjects;

public class OwnerId : ValueObject
{
    public Guid Value { get; }

    private OwnerId(Guid value)
    {
        Value = value;
    }

    public static OwnerId Create()
    {
        return new OwnerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}