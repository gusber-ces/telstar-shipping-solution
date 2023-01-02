namespace Netcompany.RoutePlanning.Web.Pages.Core;

public partial class NavMenu
{
    private bool NavMenuCollapse { get; set; } = true;

    private string? NavMenuCssClass => NavMenuCollapse ? "collapse" : null;

    private void ToggleNavMenu() => NavMenuCollapse = !NavMenuCollapse;
}
