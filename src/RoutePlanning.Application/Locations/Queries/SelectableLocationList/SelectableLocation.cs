using RoutePlanning.Domain.Locations;

namespace RoutePlanning.Application.Locations.Queries.SelectableLocationList;

public sealed record SelectableLocation(Location.LocationId LocationId, string Name);
