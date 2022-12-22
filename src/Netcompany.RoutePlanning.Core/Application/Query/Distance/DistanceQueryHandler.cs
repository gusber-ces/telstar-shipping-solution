using Netcompany.Net.Cqs.Queries;
using Netcompany.Net.DomainDrivenDesign.Services;
using Netcompany.RoutePlanning.Core.Domain.Model;
using Netcompany.RoutePlanning.Core.Domain.Service;

namespace Netcompany.RoutePlanning.Core.Application.Query.Distance;
public class DistanceQueryhandler : IQueryHandler<DistanceQuery, int>
{
    private readonly IQueryable<Location> _locations;
    private readonly IShortestDistanceService _shortestDistanceService;

    public DistanceQueryhandler(IQueryable<Location> locations, IShortestDistanceService shortestDistanceService)
    {
        _locations = locations;
        _shortestDistanceService = shortestDistanceService;
    }

    public async Task<int> Handle(DistanceQuery request, CancellationToken cancellationToken)
    {
        var source = await _locations.Get(request.SourceId, cancellationToken);
        var destination = await _locations.Get(request.DestinationId, cancellationToken);

        var distance = _shortestDistanceService.CalculateShortestDistance(source, destination);

        return distance;
    }
}
