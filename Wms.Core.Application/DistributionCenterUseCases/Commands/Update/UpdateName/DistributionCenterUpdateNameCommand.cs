using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using ErrorOr;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update.UpdateName;

public record DistributionCenterUpdateNameCommand(
    int Id, 
    string Name) : ICommand<ErrorOr<DistributionCenterResponse>>;