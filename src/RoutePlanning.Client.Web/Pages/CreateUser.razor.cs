using Microsoft.AspNetCore.Components;
using RoutePlanning.Domain.Users;

namespace RoutePlanning.Client.Web.Pages
{
    public sealed partial class CreateUser
    {

        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Role { get; set; } = "";


        private object[] FormData { get; set; } = new object[4]; // 7 is the number of fields

        private void SubmitForm()
        {
            // Here, handle form submission, e.g., send the form data to an API, save it in a database, etc.
            FormData[0] = Username;
            FormData[1] = Password;
            FormData[2] = Name;
            FormData[3] = Phone;
            FormData[4] = Role;
            
            UserService.AddUser(new User(Username, Password));
            

            // Placeholder: Here, you can process or store the FormData as needed
            // For demonstration purposes, I'll just print the array to the console (useful for debugging)
            Console.WriteLine(string.Join(", ", FormData));
        }
    }
}
