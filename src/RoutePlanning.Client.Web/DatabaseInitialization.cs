using Netcompany.Net.UnitOfWork;
using Npgsql;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Users;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Client.Web;

public static class DatabaseInitialization
{
    public static async Task SeedDatabase(WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();

        var context = serviceScope.ServiceProvider.GetRequiredService<RoutePlanningDatabaseContext>();
        await context.Database.EnsureCreatedAsync();

        var unitOfWorkManager = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
        await using (var unitOfWork = unitOfWorkManager.Initiate())
        {
            await SeedUsers(context);
            await SeedLocationsAndRoutes(context);

            unitOfWork.Commit();
        }
    }

    private static async Task SeedLocationsAndRoutes(RoutePlanningDatabaseContext context)
    {
        var kapstaden = new Location("Kapstaden");
        await context.AddAsync(kapstaden);

        var hvalbugten = new Location("Hvalbugten");
        await context.AddAsync(hvalbugten);

        var dragebjerget = new Location("Dragebjerget");
        await context.AddAsync(dragebjerget);

        var luanda = new Location("Luanda");
        await context.AddAsync(luanda);

        var victoriafaldene = new Location("Victoriafaldene");
        await context.AddAsync(victoriafaldene);

        var mozambique = new Location("Mozambique");
        await context.AddAsync(mozambique);

        var kabalo = new Location("Kabalo");
        await context.AddAsync(kabalo);

        var congo = new Location("Congo");
        await context.AddAsync(congo);

        var slavekysten = new Location("Slavekysten");
        await context.AddAsync(slavekysten);

        var darfur = new Location("Darfur");
        await context.AddAsync(darfur);

        var bahrelGhazal = new Location("Bahrel Ghazal");
        await context.AddAsync(bahrelGhazal);

        var victoriasoeen = new Location("Victoriasoeen");
        await context.AddAsync(victoriasoeen);

        var zanzibar = new Location("Zanzibar");
        await context.AddAsync(zanzibar);

        var kapGuardafui = new Location("Kap Guardafui");
        await context.AddAsync(kapGuardafui);

        var suakin = new Location("Suakin");
        await context.AddAsync(suakin);

        var omdurman = new Location("Omdurman");
        await context.AddAsync(omdurman);

        var wadai = new Location("Wadai");
        await context.AddAsync(wadai);

        var tripoli = new Location("Tripoli");
        await context.AddAsync(tripoli);

        var tunis = new Location("Tunis");
        await context.AddAsync(tunis);

        var marrakesh = new Location("Marrakesh");
        await context.AddAsync(marrakesh);

        var dakar = new Location("Dakar");
        await context.AddAsync(dakar);

        var sierraLeone = new Location("Sierra Leone");
        await context.AddAsync(sierraLeone);

        var timbuktu = new Location("Timbuktu");
        await context.AddAsync(timbuktu);

        var sahara = new Location("Sahara");
        await context.AddAsync(sahara);

        var addisAbeba = new Location("Addis Abeba");
        await context.AddAsync(addisAbeba);

        var guldkysten = new Location("Guldkysten");
        await context.AddAsync(guldkysten);

        var tanger = new Location("Tanger");
        await context.AddAsync(tanger);

        var cairo = new Location("Cairo");

        await context.SaveChangesAsync();
        
        CreateTwoWayConnection(kapstaden, hvalbugten, 4);
        var kapHval = new Domain.Locations.Route(kapstaden, hvalbugten, 4);
        await context.AddAsync(kapHval);
        CreateTwoWayConnection(hvalbugten, victoriafaldene, 4);
        CreateTwoWayConnection(victoriafaldene, dragebjerget, 3);
        CreateTwoWayConnection(victoriafaldene, mozambique, 5);
        CreateTwoWayConnection(dragebjerget, mozambique, 4);
        CreateTwoWayConnection(mozambique, luanda, 10);
        CreateTwoWayConnection(mozambique, zanzibar, 3);
        CreateTwoWayConnection(mozambique, victoriasoeen, 6);
        CreateTwoWayConnection(zanzibar, kapGuardafui, 6);
        CreateTwoWayConnection(zanzibar, victoriasoeen, 5);
        CreateTwoWayConnection(luanda, congo, 3);
        CreateTwoWayConnection(luanda, kabalo, 4);
        CreateTwoWayConnection(congo, slavekysten, 5);
        CreateTwoWayConnection(congo, wadai, 6);
        CreateTwoWayConnection(congo, darfur, 6);
        CreateTwoWayConnection(slavekysten, timbuktu, 5);
        CreateTwoWayConnection(slavekysten, wadai, 7);
        CreateTwoWayConnection(slavekysten, darfur, 7);
        CreateTwoWayConnection(timbuktu, guldkysten, 4);
        CreateTwoWayConnection(timbuktu, sierraLeone, 5);
        CreateTwoWayConnection(guldkysten, sierraLeone, 5);
        CreateTwoWayConnection(sierraLeone, dakar, 4);
        CreateTwoWayConnection(dakar, marrakesh, 8);
        CreateTwoWayConnection(marrakesh, tanger, 2);
        CreateTwoWayConnection(tanger, tunis, 5);
        CreateTwoWayConnection(tanger, sahara, 5);
        CreateTwoWayConnection(tunis, tripoli, 3);
        CreateTwoWayConnection(tripoli, omdurman, 6);
        CreateTwoWayConnection(omdurman, cairo, 4);
        CreateTwoWayConnection(wadai, darfur, 4);
        CreateTwoWayConnection(sahara, darfur, 8);
        CreateTwoWayConnection(omdurman, darfur, 3);
        CreateTwoWayConnection(darfur, suakin, 4);
        CreateTwoWayConnection(suakin, addisAbeba, 3);
        CreateTwoWayConnection(addisAbeba, kapGuardafui, 3);
    }

    private static async Task SeedUsers(RoutePlanningDatabaseContext context)
    {
        var alice = new User("alice", User.ComputePasswordHash("alice123!"));
        await context.AddAsync(alice);

        var bob = new User("bob", User.ComputePasswordHash("!CapableStudentCries25"));
        await context.AddAsync(bob);
    }

    private static void CreateTwoWayConnection(Location locationA, Location locationB, int distance)
    {
        locationA.AddConnection(locationB, distance);
        locationB.AddConnection(locationA, distance);
    }
}
