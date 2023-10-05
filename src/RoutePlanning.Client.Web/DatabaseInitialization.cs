using Netcompany.Net.UnitOfWork;
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
        var berlin = new Location("Berlin");
        await context.AddAsync(berlin);

        var copenhagen = new Location("Copenhagen");
        await context.AddAsync(copenhagen);

        var paris = new Location("Paris");
        await context.AddAsync(paris);

        var warsaw = new Location("Warsaw");
        await context.AddAsync(warsaw);

        var kapstaden = new Location("Kapstaden");
        var hvalbugten = new Location("Hvalbugten");
        var dragebjerget = new Location("Dragebjerget");
        var luanda = new Location("Luanda");
        var victoriafaldene = new Location("Victoriafaldene");
        var mozambique = new Location("Mozambique");
        var kabalo = new Location("Kabalo");
        var congo = new Location("Congo");
        var slavekysten = new Location("Slavekysten");
        var darfur = new Location("Darfur");
        var bahrelGhazal = new Location("Bahrel Ghazal");
        var victoriasoeen = new Location("Victoriasoeen");
        var zanzibar = new Location("Zanzibar");
        var kapGuardafui = new Location("Kap Guardafui");
        var suakin = new Location("Suakin");
        var omdurman = new Location("Omdurman");
        var wadai = new Location("Wadai");
        var tripoli = new Location("Tripoli");
        var tunis = new Location("Tunis");
        var marrakesh = new Location("Marrakesh");
        var dakar = new Location("Dakar");
        var sierraLeone = new Location("Sierra Leone");
        var timbuktu = new Location("Timbuktu");
        var sahara = new Location("Sahara");
        var addisAbeba = new Location("Addis Abeba");
        var guldkysten = new Location("Guldkysten");
        var tanger = new Location("Tanger");
        var cairo = new Location("Cairo");

        
        
        CreateTwoWayConnection(berlin, warsaw, 573);
        CreateTwoWayConnection(berlin, copenhagen, 763);
        CreateTwoWayConnection(berlin, paris, 1054);
        CreateTwoWayConnection(copenhagen, paris, 1362);
        CreateTwoWayConnection(kapstaden, hvalbugten, 4);
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
