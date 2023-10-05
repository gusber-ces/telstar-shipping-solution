using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Client.Web.Authorization;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
//[Authorize(nameof(TokenRequirement))]
public sealed class RoutesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly RoutePlanningDatabaseContext _context;

    public RoutesController(IMediator mediator, RoutePlanningDatabaseContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet("[action]")]
    public List<RoutePlanning.Client.Web.Pages.SearchResults.Route>? GetAllRoutes()
    {
        var json = "[{\"Locations\":[{\"Id\":1,\"Name\":\"CityA\"},{\"Id\":2,\"Name\":\"CityB\"}],\"TravelTime\":\"2 days\",\"Category\":\"Category1\",\"Price\":100,\"Date\":\"2023-01-01\"},{\"Locations\":[{\"Id\":3,\"Name\":\"CityC\"},{\"Id\":4,\"Name\":\"CityD\"}],\"TravelTime\":\"3 days\",\"Category\":\"Category2\",\"Price\":200,\"Date\":\"2023-02-02\"}]";
        var routes = JsonConvert.DeserializeObject<List<RoutePlanning.Client.Web.Pages.SearchResults.Route>>(json);
        
        return routes;
    }

    [HttpPost("[action]")]
    public async Task AddTwoWayConnection(CreateTwoWayConnectionCommand command)
    {
        await _mediator.Send(command);
    }
}
