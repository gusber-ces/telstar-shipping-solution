using Newtonsoft.Json;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Infrastructure.Database;

public class BookingService
{
    private readonly RoutePlanningDatabaseContext _context;

    public BookingService(RoutePlanningDatabaseContext context)
    {
        _context = context;
    }
    

    public static Task<List<Booking>?> GetAllBookingsAsync()
    {
        var json = "[{\"Id\":1,\"RouteId\":1,\"UserId\":1,\"Date\":\"2023-01-01\"},{\"Id\":2,\"RouteId\":2,\"UserId\":1,\"Date\":\"2023-01-02\"}]";
        var bookings = JsonConvert.DeserializeObject<List<Booking>>(json);
        return Task.FromResult(bookings);
    }
    
}
