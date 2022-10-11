using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;

namespace Wms.Core.Application.DistributionCenterUseCases.Queries;

 public record DistributionCenterQueries(
     int? Id,
     string? Code,
     string? Name,
     string? Document) : ICommand<List<DistributionCenterResponse>>;