using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProviderUseCases.Contracts;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ProviderUseCases.Commands.Update;

public class ProviderUpdateCommandHandler : ICommandHandler<ProviderUpdateCommand, ErrorOr<ProviderResponse>>
{
    readonly IProviderRepository _repository;
    readonly IMapper _mapper;

    public ProviderUpdateCommandHandler(IProviderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProviderResponse>> Handle(ProviderUpdateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Update(_mapper.Map<Provider>(command));

        return _mapper.Map<ProviderResponse>(await _repository.GetByCode(command.Code));
    }
}