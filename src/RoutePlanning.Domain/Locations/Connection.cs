using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
using static RoutePlanning.Domain.Locations.Connection;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Source} --{Distance}--> {Destination}")]
public sealed class Connection : Entity<ConnectionId>
{
    public sealed record ConnectionId : EntityId;

    public Connection(Location source, Location destination, Distance distance)
    {
        Source = source;
        Destination = destination;
        Distance = distance;
    }

    private Connection()
    {
        Source = null!;
        Destination = null!;
        Distance = null!;
    }

    public Location Source { get; private set; }

    public Location Destination { get; private set; }

    public Distance Distance { get; private set; }
}
