using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Infrastructure.Interfaces.UnitizerRepositoryInterface;

namespace Wms.Core.Application.Commands.UnitizerCommands.UnitizerTypeCommand.Delete;

public class UnitizerTypeDeleteCommandHandler : ICommandHandler<UnitizerTypeDeleteCommand, Error?>
{
    private readonly IUnitizerTypeRepository _repository;

    public UnitizerTypeDeleteCommandHandler(IUnitizerTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> Handle(UnitizerTypeDeleteCommand command, CancellationToken cancellationToken)
    {
        await _repository.Delete(await _repository.GetByCode(command.Code));

        return null;
    }
}