using Netcompany.Net.Cqs.Commands;

namespace Netcompany.RoutePlanning.Core.Application.Command.CreateTwoWayConnection;
public record CreateTwoWayConnectionCommand(long LocationAId, long LocationBId, int Distance) : ICommand;
