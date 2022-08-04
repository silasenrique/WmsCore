using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.Abstractions.Entity;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;

namespace Wms.Core.Application.Services.Entity;

public class ShippingService : IShippingService
{
    readonly IShippingRepository _repository;

    public ShippingService(IShippingRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Shipping>> Create(Shipping shipping)
    {
        var exist = await Get(new Shipping { Code = shipping.Code });
        if (exist.Any())
        {
            return Errors.Errors.Shipping.AlreadyExist;
        }

        await _repository.Insert(shipping);

        var getNewDistributionCenter = await Get(new Shipping { Code = shipping.Code });

        return getNewDistributionCenter.FirstOrDefault()!;
    }

    public async Task<Error?> Delete(string code)
    {
        await _repository.Delete(new Shipping { Code = code });

        return null;
    }

    public async Task<IEnumerable<Shipping>> Get(Shipping shipping)
    {
        Expression<Func<Shipping, bool>> getShipping = o =>
            (o.Id == shipping.Id || shipping.Id == 0) &&
            (o.Code == shipping.Code || shipping.Code == null) &&
            (o.Document == shipping.Document || shipping.Document == null) &&
            (o.Status == shipping.Status || shipping.Status == 0) &&
            (o.Name == shipping.Name || shipping.Name == null) &&
            (o.TypeDoc == shipping.TypeDoc || shipping.TypeDoc == 0);

        return await _repository.Get(getShipping);
    }

    public async Task<ErrorOr<Shipping>> Update(Shipping shipping)
    {
        var exist = await Get(new Shipping { Code = shipping.Code });
        if (!exist.Any())
        {
            return await Create(shipping);
        }

        await _repository.Update(shipping);

        var getUpdated = await Get(new Shipping { Code = shipping.Code });

        return getUpdated.FirstOrDefault()!;
    }
}