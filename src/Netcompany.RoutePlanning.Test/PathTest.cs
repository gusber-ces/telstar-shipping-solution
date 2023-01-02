using Netcompany.RoutePlanning.Core.Domain.Model;
using Netcompany.RoutePlanning.Core.Domain.Service;

namespace Netcompany.RoutePlanning.Test;

public class PathTest
{
    [Fact]
    public void ShortestPathTest()
    {
        // Arrange
        var locationA = new Location("A");
        var locationB = new Location("B");
        var locationC = new Location("C");

        locationA.AddConnection(locationB, 2);
        locationB.AddConnection(locationC, 3);
        locationA.AddConnection(locationC, 6);

        var locations = new List<Location> { locationA, locationB, locationC };

        var shortestDistanceService = new ShortestDistanceService(locations.AsQueryable());

        // Act
        var distance = shortestDistanceService.CalculateShortestDistance(locationA, locationC);

        // Assert
        Assert.Equal(5, distance);
    }
}
