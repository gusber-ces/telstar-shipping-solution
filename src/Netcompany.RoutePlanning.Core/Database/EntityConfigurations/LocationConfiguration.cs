using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcompany.Net.DomainDrivenDesign.EntityFrameworkCore;
using Netcompany.RoutePlanning.Core.Domain.Model;

namespace Netcompany.RoutePlanning.Core.Database.EntityConfigurations;

public class LocationConfiguration : EntityConfiguration<Location>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        base.Configure(builder);

        builder.HasMany(x => x.Connections).WithOne(x => x.Source);

        builder.Property(x => x.Name).HasMaxLength(256);
    }
}
