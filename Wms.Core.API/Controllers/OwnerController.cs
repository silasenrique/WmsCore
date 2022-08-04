using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.Abstractions.Entity;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.API.Controllers;

[Route("api/owner")]
public class OwnerController : MainController
{
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public async Task<ActionResult<Owner>> Get([FromQuery] Owner owner)
    {
        var get = await _ownerService.Get(owner);

        return Ok(get);
    }

    [HttpPost]
    public async Task<ActionResult<Owner>> Create(Owner owner)
    {
        var createdOwner = await _ownerService.Create(owner);

        return createdOwner.Match(
            createdOwner => Ok(createdOwner),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult> Update(Owner owner)
    {
        var updatedOwner = await _ownerService.Update(owner);

        return updatedOwner.Match(
            updatedOwner => Ok(updatedOwner),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] string code)
    {
        await _ownerService.Delete(code);

        return NoContent();
    }
}
