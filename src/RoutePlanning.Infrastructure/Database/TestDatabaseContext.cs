using Microsoft.EntityFrameworkCore;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database;

public class TestDatabaseContext: DbContext
{
    public TestDatabaseContext(DbSet<Route> routes, DbSet<Booking> bookings)
    {
        Routes = routes;
        Bookings = bookings;
    }

    public DbSet<Route> Routes { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }
}
