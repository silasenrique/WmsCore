using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.UnitizerContract;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Update;

public class UnitizerTypeUpdateCommandHandler : ICommandHandler<UnitizerTypeUpdateCommand, ErrorOr<UnitizerTypeResponse>>
{
    private readonly IUnitizerTypeRepository _repository;
    private readonly IMapper _mapper;

    public UnitizerTypeUpdateCommandHandler(IUnitizerTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<UnitizerTypeResponse>> Handle(UnitizerTypeUpdateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Update(_mapper.Map<UnitizerType>(command));

        return _mapper.Map<UnitizerTypeResponse>(await _repository.GetByCode(command.Code));
    }
}