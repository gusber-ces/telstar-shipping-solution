using Microsoft.EntityFrameworkCore;

namespace Netcompany.RoutePlanning.Core.Database;
public class RoutePlanningDatabaseContext : DbContext
{
    public RoutePlanningDatabaseContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoutePlanningDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
