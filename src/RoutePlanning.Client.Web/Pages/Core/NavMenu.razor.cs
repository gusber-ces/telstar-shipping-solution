using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace RoutePlanning.Client.Web.Pages.Core;

public sealed partial class NavMenu
{
    [Inject]
    private IServiceProvider ScopedServices { get; set; } = default!;
    private bool NavMenuCollapse { get; set; } = true;

    private string? NavMenuCssClass => NavMenuCollapse ? "collapse" : null;

    private void ToggleNavMenu() => NavMenuCollapse = !NavMenuCollapse;


    private bool ShowUserMenu { get; set; } = false;

    private void ToggleUserMenu() => ShowUserMenu = !ShowUserMenu;

    private async Task Logout()
    {
        await AuthStateProvider.ClearAuthenticationStateAsync();

        // After clearing the authentication state, redirect to the SignIn component.
        var navigationManager = (NavigationManager) ScopedServices.GetService(typeof(NavigationManager))!;
        navigationManager.NavigateTo("/signin");
    }



}
