using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Client.Web.Authorization;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
//[Authorize(nameof(TokenRequirement))]
public sealed class RoutesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IQueryable<Location> _locations;

    public RoutesController(IMediator mediator, IQueryable<Location> locations)
    {
        _mediator = mediator;
        _locations = locations;
    }

    [HttpPost("[action]")]
    public List<Location>? GetAllRoutes([FromBody]Package package)
    {
        if (package.Dimensions.Weight > 40)
        {
            return null;
        }
        var locations = _locations.ToList();
    
        return locations;
    }
    
    [HttpGet("[action]")]
    public List<Location>? GetAllRoutes()
    {
        var locations = _locations.ToList();
    
        return locations;
    }


    [HttpPost("[action]")]
    public async Task AddTwoWayConnection(CreateTwoWayConnectionCommand command)
    {
        await _mediator.Send(command);
    }
}
