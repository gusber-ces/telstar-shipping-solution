﻿using Microsoft.AspNetCore.Components;

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
        public string? Height { get; set; }
        public string? Length { get; set; }
        public string? Depth { get; set; }

        private List<string> Categories { get; set; } = new() { "General", "Live Animal", "Fragile Goods" };
        private List<string> SelectedCategories { get; set; } = new();
        private void HandleCategoryChange(ChangeEventArgs e, string category)
        {
            var isChecked = (bool)e.Value!;
            if (isChecked && !SelectedCategories.Contains(category))
            {
                SelectedCategories.Add(category);
            }
            else if (!isChecked && SelectedCategories.Contains(category))
            {
                SelectedCategories.Remove(category);
            }
        }


        private void SubmitForm()
        {
            // Here, handle form submission, e.g., send the form data to an API, save it in a database, etc.
            FormData[0] = Origin;
            FormData[1] = Destination;
            FormData[2] = DepartureTime;
            FormData[3] = ArrivalDeadline;
            FormData[4] = $"Height: {Height}, Length: {Length}, Depth: {Depth}"; // Combined dimensions
            FormData[5] = string.Join(", ", SelectedCategories); // Combined selected categories
            FormData[6] = IsRecommended;

            Console.WriteLine(string.Join(", ", FormData));
        }
    }
}
