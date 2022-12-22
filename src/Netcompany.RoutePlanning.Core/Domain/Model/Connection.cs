using Netcompany.Net.DomainDrivenDesign.Models;

namespace Netcompany.RoutePlanning.Core.Domain.Model;

public class Connection : Entity
{
    public Connection(Location source, Location destination, Distance distance)
    {
        Source = source;
        Destination = destination;
        Distance = distance;
    }

    public Location Source { get; private set; }

    public Location Destination { get; private set; }

    public Distance Distance { get; private set; }
}
