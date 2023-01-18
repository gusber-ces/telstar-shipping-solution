using System.Diagnostics;
using Netcompany.Net.DomainDrivenDesign.Models;
using static RoutePlanning.Domain.Locations.Location;

namespace RoutePlanning.Domain.Locations;

[DebuggerDisplay("{Name}")]
public sealed class Location : AggregateRoot<LocationId>
{
    public sealed record LocationId : EntityId;

    public Location(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<Connection> _connections = new();

    public IReadOnlyCollection<Connection> Connections => _connections.AsReadOnly();

    public Connection AddConnection(Location destination, int distance)
    {
        Connection connection = new(this, destination, distance);

        _connections.Add(connection);

        return connection;
    }
}
