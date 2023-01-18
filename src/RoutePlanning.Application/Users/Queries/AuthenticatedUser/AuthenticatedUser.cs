using RoutePlanning.Domain.Users;

namespace RoutePlanning.Application.Users.Queries.AuthenticatedUser;

public sealed record AuthenticatedUser(User.UserId Id, string Username);
