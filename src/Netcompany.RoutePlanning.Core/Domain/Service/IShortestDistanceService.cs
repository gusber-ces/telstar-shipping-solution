using Netcompany.RoutePlanning.Core.Domain.Model;

namespace Netcompany.RoutePlanning.Core.Domain.Service;
public interface IShortestDistanceService
{
    int CalculateShortestDistance(Location source, Location target);
}