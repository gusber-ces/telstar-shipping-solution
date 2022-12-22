using Netcompany.Net.Cqs.Queries;

namespace Netcompany.RoutePlanning.Core.Application.Query.SelectableLocationList;

public record SelectableLocationListQuery : IQuery<IReadOnlyList<SelectableLocation>>;
