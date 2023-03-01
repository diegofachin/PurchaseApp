using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /*
    [HttpPost]
    [ProducesResponseType((201))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<AddAppResponseDto>> AddApp([FromBody] AddAppRequestDto registerUserRequestDto)
    {
        var result = await _mediator.Send(registerUserRequestDto);

        return result is not null
            ? Ok(result)
            : BadRequest();
    }

    [HttpGet]
    [ProducesResponseType((201))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<ListAppResponseDto>> ListApp()
    {
        var result = await _mediator.Send(new ListAppRequestDto());

        return result is not null
            ? Ok(result)
            : BadRequest();
    }
    */

}
