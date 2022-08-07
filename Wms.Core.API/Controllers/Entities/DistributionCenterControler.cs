using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.Commands.DistributionCenterCommand;

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
    public async Task<ActionResult<DistributionCenterDTO>> Create(CreateCommand distributionCenter)
    {
        var newCenter = await _mediator.Send(distributionCenter);

        return Ok(newCenter);
    }
}