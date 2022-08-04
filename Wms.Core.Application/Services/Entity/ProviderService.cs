using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.Abstractions.Entity;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;

namespace Wms.Core.Application.Services.Entity;

public class ProviderService : IProviderService
{
    readonly IProviderRepository _repository;

    public ProviderService(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Provider>> Create(Provider provider)
    {
        var exist = await Get(new Provider { Code = provider.Code });
        if (exist.Any())
        {
            return Errors.Errors.Provider.AlreadyExist;
        }

        await _repository.Insert(provider);

        var getNewDistributionCenter = await Get(new Provider { Code = provider.Code });

        return getNewDistributionCenter.FirstOrDefault()!;
    }

    public async Task<Error?> Delete(string code)
    {
        await _repository.Delete(new Provider { Code = code });

        return null;
    }

    public async Task<IEnumerable<Provider>> Get(Provider provider)
    {
        Expression<Func<Provider, bool>> getProvider = o =>
            (o.Id == provider.Id || provider.Id == 0) &&
            (o.Code == provider.Code || provider.Code == null) &&
            (o.Document == provider.Document || provider.Document == null) &&
            (o.Status == provider.Status || provider.Status == 0) &&
            (o.Name == provider.Name || provider.Name == null) &&
            (o.TypeDoc == provider.TypeDoc || provider.TypeDoc == 0);

        return await _repository.Get(getProvider);
    }

    public async Task<ErrorOr<Provider>> Update(Provider provider)
    {
        var exist = await Get(new Provider { Code = provider.Code });
        if (!exist.Any())
        {
            return await Create(provider);
        }

        await _repository.Update(provider);

        var getUpdated = await Get(new Provider { Code = provider.Code });

        return getUpdated.FirstOrDefault()!;
    }
}