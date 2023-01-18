using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Netcompany.Net.DomainDrivenDesign.Models;
using static RoutePlanning.Domain.Users.User;

namespace RoutePlanning.Domain.Users;

[DebuggerDisplay("{Username}")]
public sealed class User : AggregateRoot<UserId>
{
    public sealed record UserId : EntityId;

    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public static string ComputePasswordHash(string password) => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
}
