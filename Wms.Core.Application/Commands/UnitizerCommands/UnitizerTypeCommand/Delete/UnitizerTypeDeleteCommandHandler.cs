using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Delete;

public class UnitizerTypeDeleteCommandHandler : ICommandHandler<UnitizerTypeDeleteCommand, Error?>
{
    private readonly IUnitizerTypeRepository _repository;
    private readonly IMapper _mapper;

    public UnitizerTypeDeleteCommandHandler(IUnitizerTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Error?> Handle(UnitizerTypeDeleteCommand command, CancellationToken cancellationToken)
    {
        await _repository.Delete(_mapper.Map<UnitizerType>(command.Code));

        return null;
    }
}