using Microsoft.AspNetCore.Components;

namespace RoutePlanning.Client.Web.Pages
{
    
    public partial class Admin
    {
        [Inject]
        public NavigationManager? NavManager { get; set; }
        
        private void GoToConfirmation(int routeId)
        {
            if (NavManager != null)
            {
                NavManager.NavigateTo($"/confirmation/{routeId}");
            }
        }
        
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
                    Date = DateTime.Now,
                    Tags = new List<Tags>
                    {
                        new Tags { tag = "Cheapest" },
                        new Tags { tag = "Telstar exclusive" },
                    },
                    Id = 1,
                    Weight = 10
                    

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
                    Date = DateTime.Now,
                    Tags = new List<Tags>
                    {
                        new Tags { tag = "Fastest" }
                    },
                    Id = 2,
                    Weight = 20
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
        
        /*private async Task CancelShipping(int routeId)
        {
            // TODO: Send a request to the API to cancel the shipping with the provided routeId.
    
            // This is a placeholder for the actual API call.
            // You'll replace the below lines with your API call when your backend is ready.
            // Example:
            // var response = await HttpClient.DeleteAsync($"https://api.example.com/cancel-booking/{routeId}");
            // if(response.IsSuccessStatusCode) 
            // {
            //     // Handle successful cancellation: e.g., show a confirmation message, refresh the list, etc.
            // }
            // else 
            // {
            //     // Handle errors: e.g., show an error message.
            // }

            Console.WriteLine($"Requested to cancel booking with ID: {routeId}");
        }*/

        
    }
    
}
