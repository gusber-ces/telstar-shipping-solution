using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;
using Netcompany.RoutePlanning.Core.Domain.Model;

namespace Netcompany.RoutePlanning.Core.Application.Query.SelectableLocationList;

public class SelectableLocationListQueryhandler : IQueryHandler<SelectableLocationListQuery, IReadOnlyList<SelectableLocation>>
{
    private readonly IQueryable<Location> _locations;

    public SelectableLocationListQueryhandler(IQueryable<Location> locations)
    {
        _locations = locations;
    }

    public async Task<IReadOnlyList<SelectableLocation>> Handle(SelectableLocationListQuery _, CancellationToken cancellationToken)
    {
        return await _locations
            .Select(l => new SelectableLocation(l.Id, l.Name))
            .ToListAsync(cancellationToken);
    }
}
