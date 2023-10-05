using Newtonsoft.Json;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Infrastructure.Database;

public class RouteService
{
    private readonly RoutePlanningDatabaseContext _context;

    public RouteService(RoutePlanningDatabaseContext context)
    {
        _context = context;
    }

    public static Task<List<Route>?> GetAllRoutes()
    {
        var json = "[{\"Id\":1,\"Origin\":\"Cario\",\"Destination\":\"Zanzibar\"},{\"Id\":2,\"Origin\":\"Chicago\",\"Destination\":\"Houston\"}]";
        var routes = JsonConvert.DeserializeObject<List<Route>>(json);
        return Task.FromResult(routes);
    }
}
