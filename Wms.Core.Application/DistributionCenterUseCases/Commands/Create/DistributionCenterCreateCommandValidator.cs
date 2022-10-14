using FluentValidation;
using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Create;

public class DistributionCenterCreateCommandValidator : AbstractValidator<DistributionCenterCreateCommand>
{
    public DistributionCenterCreateCommandValidator()
    {
        Include(new DistributionCenterCommonWriteCommandValidator());
    }
}