using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Client.Web.Authorization;
using RoutePlanning.Domain;
using RoutePlanning.Infrastructure.Database;
using Route = RoutePlanning.Domain.Locations.Route;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
//[Authorize(nameof(TokenRequirement))]
public sealed class BookingController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IQueryable<Booking> _bookings;
    private RoutePlanningDatabaseContext _context;
    

    public BookingController(IMediator mediator, IQueryable<Booking> bookings, RoutePlanningDatabaseContext context)
    {
        _mediator = mediator;
        _bookings = bookings;
        _context = context;
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        if (_context.Bookings != null)
        {
            var booking = await _context.Bookings.FindAsync(id)!;
        
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }
        else
        {
            return StatusCode(500, "Error: Booking context is null");
        }
    }
    

    [HttpGet("[action]")]
    public List<Booking> GetAllBookings()
    {
        var bookings = _bookings.ToList();
        return bookings;
    }


    
    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
    {
        if (booking == null)
        {
            return BadRequest("Booking cannot be null");
        }

        if (_context.Bookings != null)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }
        else
        {
            return StatusCode(500, "Internal server error");
        }
    }
    

    [HttpPost("[action]")]
    public async Task AddTwoWayConnection(CreateTwoWayConnectionCommand command)
    {
        await _mediator.Send(command);
    }
}
