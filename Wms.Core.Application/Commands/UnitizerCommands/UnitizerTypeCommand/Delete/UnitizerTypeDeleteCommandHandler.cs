using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
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
        var willBeDeleted = await _repository.GetByCode(command.Code);
        if (willBeDeleted is null) return null;
        
        await _repository.Delete(willBeDeleted);

        return null;
    }
}