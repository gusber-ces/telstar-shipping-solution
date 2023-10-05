using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Origin} --{Distance}--> {Destination}")]
public sealed class Route : AggregateRoot<Route>
{
    public Route(Location origin, Location destination, Distance distance)
    {
        Origin = origin;
        Destination = destination;
        Distance = distance;
    }

    private Route()
    {
        Origin = null!;
        Destination = null!;
        Distance = null!;
    }

    public Location Origin { get; private set; }

    public Location Destination { get; private set; }

    public Distance Distance { get; private set; }
}
