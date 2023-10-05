using Netcompany.Net.DomainDrivenDesign.Services;

namespace RoutePlanning.Domain.Locations.Services;

public interface IShortestDistanceService : IDomainService
{
    List<Route> CalculateShortestDistance(Location source, Location target);
}
