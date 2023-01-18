using Netcompany.Net.Cqs.Commands;
using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;

public sealed record CreateTwoWayConnectionCommand(Location.LocationId LocationAId, Location.LocationId LocationBId, int Distance) : ICommand;
