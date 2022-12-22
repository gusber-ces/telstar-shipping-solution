using Netcompany.Net.Cqs.Queries;

namespace Netcompany.RoutePlanning.Core.Application.Query.Distance;
public record DistanceQuery(long SourceId, long DestinationId) : IQuery<int>;
