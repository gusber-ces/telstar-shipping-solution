namespace RoutePlanning.Client.Web.Pages
{
    public partial class SearchResults
    {
        public List<Route>? Routes { get; set; }

        protected override void OnInitialized()
        {
            // Dummy data
            Routes = new List<Route>
            {
                new Route
                {
                    Locations = new List<Location>
                    {
                        new Location { Name = "Location A" },
                        new Location { Name = "Location B" },
                        new Location { Name = "Location C" },
                        new Location { Name = "Location D" }
                    },
                    TravelTime = "10 hours",
                    Category = "General",
                    Price = 100,
                    Date = DateTime.Now
                },
                new Route
                {
                    Locations = new List<Location>
                    {
                        new Location { Name = "Location A" },
                        new Location { Name = "Location B" },
                        new Location { Name = "Location C" },
                        new Location { Name = "Location D" }
                    },
                    TravelTime = "10 hours",
                    Category = "General",
                    Price = 100,
                    Date = DateTime.Now
                }
            };
        }

        public class Route
        {
            public List<Location>? Locations { get; set; }
            public string? TravelTime { get; set; }
            public string? Category { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
        }

        public class Location
        {
            public string? Name { get; set; }
        }
    }
}
