using Wms.Core.Domain.Common.Models;
using Wms.Core.Domain.DistributionCenter.ValueObjects;

namespace Wms.Core.Domain.DistributionCenter;

public class DistributionCenter : Entity
{
    public string Name { get; }
    public string Document { get; }

    public DistributionCenter(Guid id, string name, string document) : base(id)
    {
        Name = name;
        Document = document;
    }
}