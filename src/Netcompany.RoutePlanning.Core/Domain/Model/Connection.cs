using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace Netcompany.RoutePlanning.Core.Domain.Model;

[DebuggerDisplay("{Source} --{Distance}--> {Destination}")]
public class Connection : Entity
{
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
