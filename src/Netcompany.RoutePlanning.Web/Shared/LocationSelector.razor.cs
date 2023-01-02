using Microsoft.AspNetCore.Components;
using Netcompany.RoutePlanning.Core.Application.Query.SelectableLocationList;

namespace Netcompany.RoutePlanning.Web.Shared;

public partial class LocationSelector
{
    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public IEnumerable<SelectableLocation>? Locations { get; set; }

    [Parameter]
    public SelectableLocation? Selected { get; set; }

    [Parameter]
    public EventCallback<SelectableLocation?> SelectedChanged { get; set; }

    protected async Task OnSelectedChanged(ChangeEventArgs e)
    {
        var selectedId = long.Parse((string? )e.Value ?? "");
        Selected = Locations?.Single(l => l.LocationId == selectedId);
        await SelectedChanged.InvokeAsync(Selected);
    }
}
