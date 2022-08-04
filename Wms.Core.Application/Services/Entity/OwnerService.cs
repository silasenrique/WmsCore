using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.Abstractions.Entity;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Abstractions.Entity;

namespace Wms.Core.Application.Services.Entity;

public class OwnerService : IOwnerService
{
    readonly IOwnerRepository _repository;

    public OwnerService(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Owner>> Create(Owner owner)
    {
        var ownerNotExist = await Get(new Owner { Code = owner.Code });
        if (ownerNotExist.Any())
        {
            return Errors.Errors.Owner.AlreadyExist;
        }

        await _repository.Insert(owner);

        var newOwner = await Get(new Owner { Code = owner.Code });

        return newOwner.FirstOrDefault()!;
    }

    public async Task Delete(string code)
    {
        if (code.Length == 0)
        {
            return;
        }

        var owner = new Owner
        {
            Code = code
        };

        var getOwner = await Get(owner);
        if (!getOwner.Any())
        {
            return;
        }

        await _repository.Delete(getOwner.FirstOrDefault()!);
    }

    public async Task<IEnumerable<Owner>> Get(Owner owner)
    {
        Expression<Func<Owner, bool>> getOwner = o =>
            (o.Id == owner.Id || owner.Id == 0) &&
            (o.Code == owner.Code || owner.Code == null) &&
            (o.Document == owner.Document || owner.Document == null) &&
            (o.Status == owner.Status || owner.Status == 0) &&
            (o.Name == owner.Name || owner.Name == null) &&
            (o.TypeDoc == owner.TypeDoc || owner.TypeDoc == 0);

        return await _repository.Get(getOwner);
    }

    public async Task<ErrorOr<Owner>> Update(Owner owner)
    {
        var getOldOwner = await Get(new Owner { Code = owner.Code });
        if (getOldOwner == null)
        {
            return await Create(owner);
        }

        owner.Id = getOldOwner.FirstOrDefault()!.Id;

        await _repository.Update(owner);

        return owner;
    }
}