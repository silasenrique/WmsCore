using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;

namespace Wms.Core.Application.Queries.Entity.DistributionCenterQueries;

public record DistributionCenterByCodeQuery : ICommand<DistributionCenterResponse>
{
    public string Code { get; set; }
}