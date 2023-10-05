using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Domain;

public class Booking
{
    public long Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime Departure { get; set; }
    public DateTime ArrivalDeadline { get; set; }
    public int Price { get; set; }
    public Package Package { get; set; }
    public List<Route> Routes { get; set; }

    public Booking(long id, string origin, string destination, DateTime departure,
        DateTime arrivalDeadline, int price, Package package, List<Route> routes)
    {
        Id = id;
        Origin = origin;
        Destination = destination;
        Departure = departure;
        ArrivalDeadline = arrivalDeadline;
        Price = price;
        Package = package;
        Routes = routes;
    }
}

