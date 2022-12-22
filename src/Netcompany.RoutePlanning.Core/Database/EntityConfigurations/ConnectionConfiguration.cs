using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcompany.Net.DomainDrivenDesign.EntityFrameworkCore;
using Netcompany.RoutePlanning.Core.Domain.Model;

namespace Netcompany.RoutePlanning.Core.Database.EntityConfigurations;

public class ConnectionConfiguration : EntityConfiguration<Connection>
{
    public override void Configure(EntityTypeBuilder<Connection> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Destination).WithMany();
    }
}
