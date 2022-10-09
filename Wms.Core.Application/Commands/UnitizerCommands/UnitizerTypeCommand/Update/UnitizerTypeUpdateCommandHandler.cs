using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.UnitizerContract;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Update;

public class UnitizerTypeUpdateCommandHandler : ICommandHandler<UnitizerTypeUpdateCommand, ErrorOr<UnitizerTypeResponse>>
{
    private readonly IUnitizerTypeRepository _repository;

    public UnitizerTypeUpdateCommandHandler(IUnitizerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<UnitizerTypeResponse>> Handle(UnitizerTypeUpdateCommand command, CancellationToken cancellationToken)
    {
        UnitizerType updateUnitizerType = new(
            command.Id,
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
        
        await _repository.Update(updateUnitizerType);

        updateUnitizerType = await _repository.GetByCode(command.Code);

        return new UnitizerTypeResponse(
            updateUnitizerType.Id, 
            updateUnitizerType.Code, 
            updateUnitizerType.Description, 
            updateUnitizerType.MaximumWeight, 
            updateUnitizerType.WeightUnit, 
            updateUnitizerType.Height, 
            updateUnitizerType.HeightUnit, 
            updateUnitizerType.Width, 
            updateUnitizerType.WidthUnit, 
            updateUnitizerType.Length, 
            updateUnitizerType.LengthUnit, 
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(updateUnitizerType.CreationDate).ToLocalTime().ToString(), 
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(updateUnitizerType.LastChangeDate).ToLocalTime().ToString());
    }
}