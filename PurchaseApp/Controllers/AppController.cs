using Application.Handlers.AddApp;
using Application.Handlers.ListApp;
using Application.Handlers.ListApps;
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
    
    [HttpPost]
    [ProducesResponseType((201))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<string>> AddApp([FromBody] AddAppRequestDto registerUserRequestDto)
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
    public async Task<ActionResult<ListAppsResponseDto>> ListApp()
    {
        var result = await _mediator.Send(new ListAppsRequestDto());

        return result is not null
            ? Ok(result)
            : NoContent();
    }
    

}
