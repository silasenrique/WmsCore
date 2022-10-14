using FluentValidation;
using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update;

public class DistributionCenterUpdateCommandValidator : AbstractValidator<DistributionCenterUpdateCommand>
{
    public DistributionCenterUpdateCommandValidator()
    {
        Include(new DistributionCenterCommonWriteCommandValidator());
    }
}