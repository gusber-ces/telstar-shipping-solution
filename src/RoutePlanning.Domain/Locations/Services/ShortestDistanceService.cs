using Microsoft.EntityFrameworkCore;

namespace RoutePlanning.Domain.Locations.Services;

public sealed class ShortestDistanceService : IShortestDistanceService
{
    private readonly IQueryable<Location> _locations;

    public ShortestDistanceService(IQueryable<Location> locations)
    {
        _locations = locations;
    }

    public int CalculateShortestDistance(Location source, Location target)
    {
        var locations = _locations.Include(l => l.Connections).ThenInclude(c => c.Destination);

        var path = CalculateShortestPath(locations, source, target);

        return path.Sum(c => c.Distance);
    }

    /// <summary>
    /// An implementation of the Dijkstra's shortest path algorithm
    /// </summary>
    private static IEnumerable<Route> CalculateShortestPath(IEnumerable<Location> locations, Location start, Location end)
    {
        var shortestConnections = CalculateShortestConnections(locations, start, end);

        var path = ConstructShortestPath(start, end, shortestConnections);

        return path;
    }

    /// <summary>
    /// An implementation of the Dijkstra's algorithm that computes the shortest connections to all locations until the end location is reached
    /// </summary>
    private static Dictionary<Location, (Route? SourceConnection, int Distance)> CalculateShortestConnections(IEnumerable<Location> locations, Location start, Location end)
    {
        var shortestConnections = new Dictionary<Location, (Route? SourceConnection, int Distance)>();
        var unvisitedLocations = locations.ToHashSet();

        foreach (var location in unvisitedLocations)
        {
            shortestConnections[location] = (SourceConnection: null, Distance: int.MaxValue);
        }

        shortestConnections[start] = (SourceConnection: null, Distance: 0);

        while (unvisitedLocations.Count > 0)
        {
            var location = unvisitedLocations.OrderBy(location => shortestConnections[location].Distance).First();

            if (location == end)
            {
                break;
            }

            foreach (var connection in location.Connections)
            {
                UpdateShortestConnections(shortestConnections, location, connection);
            }

            unvisitedLocations.Remove(location);
        }

        return shortestConnections;
    }

    private static void UpdateShortestConnections(Dictionary<Location, (Route? SourceConnection, int Distance)> shortestConnections, Location location, Route route)
    {
        var distance = shortestConnections[location].Distance + route.Distance;

        if (distance < shortestConnections[route.Destination].Distance)
        {
            shortestConnections[route.Destination] = (SourceConnection: route, Distance: distance);
        }
    }

    /// <summary>
    /// The shortest path is constructed by backtracking the Dijkstra connection data from the end location
    /// </summary>
    private static IEnumerable<Route> ConstructShortestPath(Location start, Location end, Dictionary<Location, (Route? SourceConnection, int Distance)> sourceConnections)
    {
        var path = new List<Route>();
        var location = end;

        while (location != start)
        {
            var shortestConnection = sourceConnections[location].SourceConnection!;
            path.Add(shortestConnection);
            location = shortestConnection.Origin;
        }

        path.Reverse();

        return path;
    }
}
