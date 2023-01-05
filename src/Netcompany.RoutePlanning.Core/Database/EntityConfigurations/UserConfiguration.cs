using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netcompany.Net.DomainDrivenDesign.EntityFrameworkCore;
using Netcompany.RoutePlanning.Core.Domain.Model;

namespace Netcompany.RoutePlanning.Core.Database.EntityConfigurations;

public class UserConfiguration : EntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Username);
        builder.Property(x => x.PasswordHash);
    }
}
