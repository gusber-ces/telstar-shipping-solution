using Netcompany.Net.UnitOfWork;
using RoutePlanning.Client.Web.Pages;
using RoutePlanning.Domain;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Users;
using RoutePlanning.Infrastructure.Database;
using Route = RoutePlanning.Domain.Locations.Route;

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
            await seedBookings(context);

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
        await context.AddAsync(cairo);

        await context.SaveChangesAsync();

        
        
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

    private static async Task seedBookings(RoutePlanningDatabaseContext context)
    {
        var dimensions1 = new Dimensions(weight: 10, height: 20, width: 15, length: 25);
        var route1 = new RoutePlanning.Domain.Locations.Route(new Location("Cairo"), new Location("Zanzibar"),
            new Distance(100));
        var route2 = new RoutePlanning.Domain.Locations.Route(new Location("Cairo"), new Location("Zanzibar"),
            new Distance(200));
        var routes1 = new List<Route> { route1, route2 };
        var dimensions2 = new Dimensions(weight: 5, height: 10, width: 8, length: 12);
        var categories1 = new List<Category> { Category.LiveAnimals, Category.Weapons };
        var categories2 = new List<Category> { Category.Weapons, Category.CautiousParcels };
        var booking1 = new Booking(
            id: 1,
            origin: "New York",
            destination: "Los Angeles",
            departure: new DateTime(2023, 6, 1, 9, 0, 0), // Departure on June 1, 2023 at 9:00
            arrivalDeadline: new DateTime(2023, 6, 5, 18, 0, 0), // Arrival deadline on June 5, 2023 at 18:00
            price: 200,
            package: new Package(dimensions: dimensions1,
                categories: categories1,
                recorded: true),
            routes: routes1
        );
        await context.AddAsync(booking1);
        
        var booking2 = new Booking(
            id: 2,
            origin: "New York",
            destination: "Los Angeles",
            departure: new DateTime(2023, 6, 1, 9, 0, 0), // Departure on June 1, 2023 at 9:00
            arrivalDeadline: new DateTime(2023, 6, 5, 18, 0, 0), // Arrival deadline on June 5, 2023 at 18:00
            price: 200,
            package: new Package(dimensions: dimensions1,
                categories: categories2,
                recorded: true),
            routes: routes1
        );
        await context.AddAsync(booking2);
        
        await context.SaveChangesAsync();
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
