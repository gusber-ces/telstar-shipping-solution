using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Name}")]
public sealed class Location : AggregateRoot<Location>
{
    public Location(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<Route> _connections = new();

    public IReadOnlyCollection<Route> Connections => _connections.AsReadOnly();

    public Route AddConnection(Location destination, int distance)
    {
        Route route = new(this, destination, distance);

        _connections.Add(route);

        return route;
    }
}
