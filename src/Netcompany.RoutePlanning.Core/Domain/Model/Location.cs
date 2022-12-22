using Netcompany.Net.DomainDrivenDesign.Models;

namespace Netcompany.RoutePlanning.Core.Domain.Model;

public class Location : AggregateRoot
{
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
