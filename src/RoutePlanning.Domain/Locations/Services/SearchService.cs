using Microsoft.EntityFrameworkCore;

namespace RoutePlanning.Domain.Locations.Services;

public class SearchService
{
    private readonly IShortestDistanceService _shortestDistanceService;

    private readonly IQueryable<Route> _routes;

    private readonly IQueryable<Location> _locations;

    public SearchService(IShortestDistanceService shortestDistanceService, IQueryable<Route> routes, IQueryable<Location> locations)
    {
        _shortestDistanceService = shortestDistanceService;
        _routes = routes;
        _locations = locations;
    }

    public IEnumerable<(Route route, double price)> GetRoutes(string origin, string destination, DateTime arrivalDeadline, Package package)
    {
        var originLocation = _locations.ToList().Find(l => l.Name == origin) ?? throw new NullReferenceException();
        var destinationLocation = _locations.ToList().Find(l => l.Name == destination) ?? throw new NullReferenceException();
        if (package.Categories.Contains(Category.Weapons) || package.Dimensions.Weight > 40)
        {
            return new List<(Route, double)>();
        }
        
        var routes = _routes.Include(r => r.Origin).Include(r => r.Destination).ToList();
        
            var shortestRoute = _shortestDistanceService.CalculateShortestDistance(originLocation, destinationLocation);
            if (arrivalDeadline < DateTime.Now.AddHours(shortestRoute.Sum(c => c.Distance)))
            {
                return new List<(Route, double)>();
            }  

        // Calculate the price for each route and return a tuple of Route and Price
        var routesWithPrice = shortestRoute.Select(r => (route: r, price: PriceService.CalculatePrice(package) * r.Distance));

        return routesWithPrice;
    }
}
