using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Entity.Provider;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Create;

public class ProviderCreateCommandHandler : ICommandHandler<ProviderCreateCommand, ErrorOr<ProviderResponse>>
{
    readonly IProviderRepository _repository;
    readonly IMapper _mapper;

    public ProviderCreateCommandHandler(IProviderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProviderResponse>> Handle(ProviderCreateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Insert(_mapper.Map<Provider>(command));

        return _mapper.Map<ProviderResponse>(await _repository.GetByCode(command.Code));
    }
}