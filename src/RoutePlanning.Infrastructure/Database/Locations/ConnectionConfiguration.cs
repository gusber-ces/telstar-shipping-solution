using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Infrastructure.Database.Locations;

public sealed class ConnectionConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Destination).WithMany();

        builder.OwnsOne(x => x.Distance);
    }
}
