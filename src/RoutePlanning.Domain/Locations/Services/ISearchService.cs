namespace RoutePlanning.Domain.Locations.Services;

public interface ISearchService
{
    public IEnumerable<(Route route, double price)> GetRoutes(string origin, string destination,
        DateTime arrivalDeadline, Package package);
}
