using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using ErrorOr;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update.UpdateDocument;

public record DistributionCenterUpdateDocumentCommand(
    int Id, 
    string Document) : ICommand<ErrorOr<DistributionCenterResponse>>;