using Microsoft.AspNetCore.Components;
using MediatR;
using Netcompany.RoutePlanning.Core.Application.Query.AuthenticatedUser;
using Netcompany.RoutePlanning.Web.Authentication;

namespace Netcompany.RoutePlanning.Web.Pages.Core;

public partial class LoginDisplay
{
    private string Username { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;
    private AuthenticatedUser? User { get; set; }
    private bool ShowAuthError { get; set; } = false;

    [Inject]
    private SimpleAuthenticationStateProvider AuthStateProvider { get; set; } = default!;

    [Inject]
    private IMediator Mediator { get; set; } = default !;

    protected async Task Login()
    {
        User = await Mediator.Send(new AuthenticatedUserQuery(Username, Password), CancellationToken.None);

        ShowAuthError = User is null;

        if (User is not null)
        {
            await AuthStateProvider.SetAuthenticationStateAsync(new UserSession(User.Username));
        }
    }

    protected async Task Logout()
    {
        await AuthStateProvider.ClearAuthenticationStateAsync();

        ShowAuthError = false;
    }
}
