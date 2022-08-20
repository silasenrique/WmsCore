using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Create;
using Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Delete;
using Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Update;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using Wms.Core.Application.Queries.Entity.DistributionCenterQueries;

namespace Wms.Core.API.Controllers.Entities;

[Route("api/cd")]
public class DistributionCenterController : MainController
{
    readonly ISender _mediator;

    public DistributionCenterController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<DistributionCenterResponse>> Create(DistributionCenterCreateCommand distributionCenter)
    {
        var newCenter = await _mediator.Send(distributionCenter);

        return newCenter.Match(
            newCenter => Ok(newCenter),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult<DistributionCenterResponse>> Update(DistributionCenterUpdateCommand distributionCenter)
    {
        var updated = await _mediator.Send(distributionCenter);

        return updated.Match(
            updated => Ok(updated),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DistributionCenterDeleteCommand command)
    {
        var err = await _mediator.Send(command);

        if (err != null)
        {
            return BadRequest(err);
        }

        return NoContent();
    }

    public async Task<ActionResult<List<DistributionCenterResponse>>> Get([FromQuery] DistributionCenterQueries query)
    {
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}