using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.Abstractions.Entity;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;

namespace Wms.Core.Application.Services.Entity;

public class DistributionCenterService : IDistributionCenterService
{
    readonly IDistributionCenterRepository _repository;

    public DistributionCenterService(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<DistributionCenter>> Create(DistributionCenter distributionCenter)
    {
        var distributionCenterExists = await Get(new DistributionCenter { Code = distributionCenter.Code });
        if (distributionCenterExists.Any())
        {
            return Errors.Errors.DistributionCenter.AlreadyExist;
        }

        await _repository.Insert(distributionCenter);

        var getNewDistributionCenter = await Get(new DistributionCenter { Code = distributionCenter.Code });

        return getNewDistributionCenter.FirstOrDefault()!;
    }

    public async Task<Error?> Delete(string code)
    {
        //TODO: adicionar tratativa que cheque se possui constraints criadas

        await _repository.Delete(new DistributionCenter { Code = code });

        return null;
    }

    public async Task<IEnumerable<DistributionCenter>> Get(DistributionCenter distributionCenter)
    {
        Expression<Func<DistributionCenter, bool>> expression = e =>
        (e.Id == distributionCenter.Id || distributionCenter.Id == 0) &&
        (e.Code == distributionCenter.Code || distributionCenter.Code == null) &&
        (e.Document == distributionCenter.Document || distributionCenter.Document == 0);

        return await _repository.Get(expression);
    }

    public async Task<ErrorOr<DistributionCenter>> Update(DistributionCenter distributionCenter)
    {
        var distributionCenterExists = await Get(new DistributionCenter { Code = distributionCenter.Code });
        if (!distributionCenterExists.Any())
        {
            return await Create(distributionCenter);
        }

        await _repository.Update(distributionCenter);

        var getUpdatedDistribution = await Get(new DistributionCenter { Code = distributionCenter.Code });

        return getUpdatedDistribution.FirstOrDefault()!;
    }
}