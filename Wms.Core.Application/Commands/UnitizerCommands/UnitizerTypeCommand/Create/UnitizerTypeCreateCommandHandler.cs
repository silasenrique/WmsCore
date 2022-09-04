using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.UnitizerContract;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Create;

public class UnitizerTypeCreateCommandHandler : ICommandHandler<UnitizerTypeCreateCommand, ErrorOr<UnitizerTypeResponse>>
{
    readonly IUnitizerTypeRepository _repository;
    readonly IMapper _mapper;

    public UnitizerTypeCreateCommandHandler(IUnitizerTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<UnitizerTypeResponse>> Handle(UnitizerTypeCreateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Insert(_mapper.Map<UnitizerType>(command));

        return _mapper.Map<UnitizerTypeResponse>(await _repository.GetByCode(command.Code));
    }
}