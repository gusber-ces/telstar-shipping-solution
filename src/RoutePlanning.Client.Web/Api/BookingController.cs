using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Client.Web.Authorization;
using RoutePlanning.Domain;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
//[Authorize(nameof(TokenRequirement))]
public sealed class BookingController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public List<Booking>? getAllBookings()
    {
        var json = "[{\"Id\":1,\"RouteId\":1,\"UserId\":1,\"Date\":\"2023-01-01\"},{\"Id\":2,\"RouteId\":2,\"UserId\":1,\"Date\":\"2023-01-02\"}]";
        var bookings = JsonConvert.DeserializeObject<List<Booking>>(json);
        return bookings;
    }
    

    
    


    [HttpPost("[action]")]
    public async Task AddTwoWayConnection(CreateTwoWayConnectionCommand command)
    {
        await _mediator.Send(command);
    }
}
