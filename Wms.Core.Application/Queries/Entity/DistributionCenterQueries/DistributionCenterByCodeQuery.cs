using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;

namespace Wms.Core.Application.Queries.Entity.DistributionCenterQueries;

public record DistributionCenterByCodeQuery(string Code) : ICommand<DistributionCenterResponse>;