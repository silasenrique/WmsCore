using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.UnitizerContract;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Create;

public class UnitizerTypeCreateCommandHandler : ICommandHandler<UnitizerTypeCreateCommand, ErrorOr<UnitizerTypeResponse>>
{
    private readonly IUnitizerTypeRepository _repository;

    public UnitizerTypeCreateCommandHandler(IUnitizerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<UnitizerTypeResponse>> Handle(UnitizerTypeCreateCommand command, CancellationToken cancellationToken)
    {
        UnitizerType newUnitizerType = new(
            command.Code,
            command.Description,
            command.MaximumWeight,
            command.WeightUnit,
            command.Height,
            command.HeightUnit,
            command.Width,
            command.WidthUnit,
            command.Length,
            command.LengthUnit);
        
        await _repository.Insert(newUnitizerType);

        var unitizerType = await _repository.GetByCode(command.Code);
        
        return new UnitizerTypeResponse(
            unitizerType.Id, 
            unitizerType.Code, 
            unitizerType.Description, 
            unitizerType.MaximumWeight, 
            unitizerType.WeightUnit, 
            unitizerType.Height, 
            unitizerType.HeightUnit, 
            unitizerType.Width, 
            unitizerType.WidthUnit, 
            unitizerType.Length, 
            unitizerType.LengthUnit, 
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unitizerType.CreationDate).ToLocalTime().ToString(), 
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unitizerType.LastChangeDate).ToLocalTime().ToString());
    }
}