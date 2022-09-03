using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.DistributionCenter;

namespace Wms.Core.Application.Queries.EntityQuery.DistributionCenterQueries;

public record DistributionCenterQueries : ICommand<List<DistributionCenterResponse>>
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
}