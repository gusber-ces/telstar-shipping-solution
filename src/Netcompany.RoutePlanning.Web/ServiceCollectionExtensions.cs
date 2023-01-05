using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Netcompany.RoutePlanning.Core.Database;
using Netcompany.RoutePlanning.Web.Authentication;
using Netcompany.RoutePlanning.Web.Authorization;

namespace Netcompany.RoutePlanning.Web;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleAuthentication(this IServiceCollection services)
    {
        services.AddScoped<ProtectedBrowserStorage, ProtectedSessionStorage>();
        services.AddScoped<SimpleAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<SimpleAuthenticationStateProvider>());
    }

    public static void AddApiTokenAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAuthorizationHandler, TokenRequirementHandler>();
        services.AddAuthorization(options =>
        {
            var apiToken = configuration.GetValue<string>("ApiToken")!;
            options.AddPolicy(nameof(TokenRequirement), policy => policy.AddRequirements(new TokenRequirement(apiToken)));
        });
    }

    public static void AddInmemoryDatabase(this IServiceCollection services)
    {
        var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
        keepAliveConnection.Open();
        services.AddDbContext<RoutePlanningDatabaseContext>(builder =>
        {
            builder.UseSqlite(keepAliveConnection);
            builder.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
        });
    }
}
