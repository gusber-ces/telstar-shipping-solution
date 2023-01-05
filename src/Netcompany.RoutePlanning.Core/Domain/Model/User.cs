using System.Security.Cryptography;
using System.Text;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace Netcompany.RoutePlanning.Core.Domain.Model;

public class User : AggregateRoot
{
    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public static string ComputePasswordHash(string password) => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
}
