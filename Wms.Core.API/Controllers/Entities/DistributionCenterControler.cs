using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.Commands.Entity.DistributionCenter.Common;
using Wms.Core.Application.DTOs;

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
    public async Task<ActionResult<DistributionCenterDTO>> Create(DistributionCenterWriteCommand distributionCenter)
    {
        var newCenter = await _mediator.Send(distributionCenter);

        return newCenter.Match(
            newCenter => Ok(newCenter),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult<DistributionCenterDTO>> Update(DistributionCenterUpdateCommand distributionCenter)
    {
        var newCenter = await _mediator.Send(distributionCenter);

        return newCenter.Match(
            newCenter => Ok(newCenter),
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
}