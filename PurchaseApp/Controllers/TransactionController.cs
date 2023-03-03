using Application.Handlers.AddApp;
using Application.Handlers.AddPurchase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType((201))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<string>> AddPurchaseApp([FromBody] AddPurchaseRequestDto registerUserRequestDto)
    {
        var result = await _mediator.Send(registerUserRequestDto);

        return result is not null
            ? Ok(result)
            : BadRequest();
    }
}
