using Microsoft.AspNetCore.Components;

namespace RoutePlanning.Client.Web.Pages
{
    public partial class Confirmation
    {
        [Parameter]
        public int RouteId { get; set; }
        
        public List<Route>? Routes { get; set; }

        protected override void OnInitialized()
        {

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
                    Date = DateTime.Now,
                    Tags = new List<Tags>
                    {
                        new Tags { tag = "Cheapest" }, new Tags { tag = "Telstar exclusive" },
                    },
                    Id = 1,
                    Weight = 10
                }
            };

            Console.WriteLine(RouteId);
        }

        public class Route
        {
            public List<Location>? Locations { get; set; }
            public string? TravelTime { get; set; }
            public string? Category { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
            public List<Tags>? Tags { get; set; }
            
            public double? Weight { get; set; }
            
            public int Id { get; set; }
        }

        public class Location
        {
            public string? Name { get; set; }
        }
        public class Tags
        {
            public string? tag { get; set; }
        }

        private static string GetTagClass(string? tagName)
        {
            return tagName switch
            {
                "Cheapest" => "cheapest",
                "Fastest" => "fastest",
                "Telstar exclusive" => "telstarExclusive",
                _ => ""
            };
        }

      
    }
    
}
