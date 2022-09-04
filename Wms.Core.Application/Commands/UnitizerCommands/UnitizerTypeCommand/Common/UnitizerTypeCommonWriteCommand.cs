using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.UnitizerContract;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Common;

public record UnitizerTypeCommonWriteCommand(
        string Code,
        string Description,
        float MaximumWeight,
        WeightUnit WeightUnit,
        float Height,
        SizeUnit HeightUnit,
        float Width,
        SizeUnit WidthUnit,
        float Length,
        SizeUnit LengthUnit) : ICommand<ErrorOr<UnitizerTypeResponse>>;