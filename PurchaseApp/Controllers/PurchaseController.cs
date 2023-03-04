using Application.Handlers.AddApp;
using Application.Handlers.AddPurchase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public PurchaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType((201))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> AddPurchaseApp([FromBody] AddPurchaseRequestDto addPurchaseRequestDto)
    {
        var result = await _mediator.Send(addPurchaseRequestDto);

        return result is not null
            ? Ok(result)
            : BadRequest();
    }
}
