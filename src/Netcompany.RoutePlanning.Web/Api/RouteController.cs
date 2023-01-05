using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netcompany.RoutePlanning.Core.Application.Command.CreateTwoWayConnection;
using Netcompany.RoutePlanning.Web.Authorization;

namespace Netcompany.RoutePlanning.Web.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(nameof(TokenRequirement))]
public class RoutesController : Controller
{
    private readonly IMediator _mediator;

    public RoutesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public IActionResult HelloWorld()
    {
        return Ok("Hello world");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddTwoWayConnection(CreateTwoWayConnectionCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
