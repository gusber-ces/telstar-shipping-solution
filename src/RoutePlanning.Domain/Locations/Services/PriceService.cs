namespace RoutePlanning.Domain.Locations.Services;

public class PriceService
{
    private readonly IQueryable<Location> _routes;

    public PriceService(IQueryable<Location> locations)
    {
        _routes = locations;
    }
}
