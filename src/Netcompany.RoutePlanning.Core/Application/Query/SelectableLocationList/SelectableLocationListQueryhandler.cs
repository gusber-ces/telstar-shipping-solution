using Microsoft.EntityFrameworkCore;
using Netcompany.Net.Cqs.Queries;

namespace Netcompany.RoutePlanning.Core.Application.Query.SelectableLocationList;

public class SelectableLocationListQueryhandler : IQueryHandler<SelectableLocationListQuery, IReadOnlyList<SelectableLocation>>
{
    private readonly IQueryable<Domain.Model.Location> _locations;

    public SelectableLocationListQueryhandler(IQueryable<Domain.Model.Location> locations)
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
