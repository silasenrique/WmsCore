using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Wms.Core.API.Controllers.Entities;

[Route("api/shipping")]
public class ShippingController : MainController
{
    readonly ISender _sender;

    public ShippingController(ISender sender)
    {
        _sender = sender;
    }
}