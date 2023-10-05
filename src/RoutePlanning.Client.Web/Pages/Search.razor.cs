using Microsoft.AspNetCore.Components;

namespace RoutePlanning.Client.Web.Pages
{
    public sealed partial class Search
    {
        private string Origin { get; set; } = "CountryA";
        private string Destination { get; set; } = "CountryA";
        
        private List<string> countries = new() { "CountryA", "CountryB", "CountryC" };
        
        private void OnOriginChanged(string value)
        {
            Origin = value;
        }

        private void OnDestinationChanged(string value)
        {
            Destination = value;
        }
        
        private DateTime DepartureTime { get; set; } = DateTime.Now;
        private DateTime ArrivalDeadline { get; set; } = DateTime.Now;
        private string Weight { get; set; } = "";
        private string Category { get; set; } = "general";
        private bool IsRecommended { get; set; } = false;

        // When you click Submit, for now just a placeholder function
        private object[] FormData { get; set; } = new object[7]; // 7 is the number of fields
        private void SubmitForm()
        {
            // Here, handle form submission, e.g., send the form data to an API, save it in a database, etc.
            FormData[0] = Origin;
            FormData[1] = Destination;
            FormData[2] = DepartureTime;
            FormData[3] = ArrivalDeadline;
            FormData[4] = Weight;
            FormData[5] = Category;
            FormData[6] = IsRecommended;

            // Placeholder: Here, you can process or store the FormData as needed
            // For demonstration purposes, I'll just print the array to the console (useful for debugging)
            Console.WriteLine(string.Join(", ", FormData));
        }
    }
}
