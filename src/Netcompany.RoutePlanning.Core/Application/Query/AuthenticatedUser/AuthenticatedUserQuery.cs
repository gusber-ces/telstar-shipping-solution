using Netcompany.Net.Cqs.Queries;

namespace Netcompany.RoutePlanning.Core.Application.Query.AuthenticatedUser;
public record AuthenticatedUserQuery(string Username, string Password) : IQuery<AuthenticatedUser?>;
