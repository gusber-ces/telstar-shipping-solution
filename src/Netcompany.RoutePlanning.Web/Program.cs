using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Netcompany.Net.UnitOfWork;
using Netcompany.RoutePlanning.Core;
using Netcompany.RoutePlanning.Core.Database;
using Netcompany.RoutePlanning.Core.Domain.Model;
using Netcompany.RoutePlanning.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

builder.Services.AddSingleton<IAuthorizationHandler, TokenRequirementHandler>();
builder.Services.AddAuthorization(options =>
{
    var apiToken = builder.Configuration.GetValue<string>("ApiToken")!;
    options.AddPolicy(nameof(TokenRequirement), policy => policy.AddRequirements(new TokenRequirement(apiToken)));
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

AddInmemoryDatabase(builder.Services);

builder.Services.AddRoutePlanningDomain(builder.Configuration);

var app = builder.Build();

await InitializeDatabase(app);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

static void AddInmemoryDatabase(IServiceCollection services)
{
    var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
    keepAliveConnection.Open();
    services.AddDbContext<RoutePlanningDatabaseContext>(builder =>
    {
        builder.UseSqlite(keepAliveConnection);
        builder.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
    });
}

static async Task InitializeDatabase(WebApplication app)
{
    using var serviceScope = app.Services.CreateScope();

    var context = serviceScope.ServiceProvider.GetRequiredService<RoutePlanningDatabaseContext>();
    await context.Database.EnsureCreatedAsync();

    var unitOfWorkManager = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
    await using (var unitOfWork = unitOfWorkManager.Initiate())
    {
        await SeedDatabase(context);

        await unitOfWork.SaveChanges(CancellationToken.None);
    }
}

static async Task SeedDatabase(RoutePlanningDatabaseContext context)
{
    var berlin = new Location("Berlin");
    await context.AddAsync(berlin);

    var copenhagen = new Location("Copenhagen");
    await context.AddAsync(copenhagen);

    var paris = new Location("Paris");
    await context.AddAsync(paris);

    var warsaw = new Location("Warsaw");
    await context.AddAsync(warsaw);

    CreateTwoWayConnection(berlin, warsaw, 573);
    CreateTwoWayConnection(berlin, copenhagen, 763);
    CreateTwoWayConnection(berlin, paris, 1054);
    CreateTwoWayConnection(copenhagen, paris, 1362);
}

static void CreateTwoWayConnection(Location locationA, Location locationB, int distance)
{
    locationA.AddConnection(locationB, distance);
    locationB.AddConnection(locationA, distance);
}
