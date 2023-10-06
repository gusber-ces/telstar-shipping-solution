using Microsoft.EntityFrameworkCore;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Users;

namespace RoutePlanning.Infrastructure.Database;
public sealed class RoutePlanningDatabaseContext : DbContext
{
    public RoutePlanningDatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    { }
    
    public DbSet<Booking>? Bookings { get; set; }
    
    public DbSet<User>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<List<Category>>().HasNoKey();
        modelBuilder.Entity<Package>()
            .Ignore(p => p.Dimensions);
        modelBuilder.Entity<Package>()
            .Ignore(p => p.Categories);
        modelBuilder.Entity<Dimensions>().HasNoKey();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoutePlanningDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
