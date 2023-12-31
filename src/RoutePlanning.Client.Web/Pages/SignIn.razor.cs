﻿using Microsoft.AspNetCore.Components;
using MediatR;
using RoutePlanning.Application.Users.Queries.AuthenticatedUser;
using RoutePlanning.Client.Web.Authentication;

namespace RoutePlanning.Client.Web.Pages;

public sealed partial class SignIn
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    private string Username { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;
    private AuthenticatedUser? User { get; set; }
    private bool ShowAuthError { get; set; } = false;

    [Inject]
    private SimpleAuthenticationStateProvider AuthStateProvider { get; set; } = default!;

    [Inject]
    private IMediator Mediator { get; set; } = default!;

    private async Task Login()
    {
        User = await Mediator.Send(new AuthenticatedUserQuery(Username, Password), CancellationToken.None);

        ShowAuthError = User is null;

        if (User is not null)
        {
            await AuthStateProvider.SetAuthenticationStateAsync(new UserSession(User.Username));
            // Redirect to the search page
            NavigationManager.NavigateTo("/search");
        }
    }

    private async Task Logout()
    {
        await AuthStateProvider.ClearAuthenticationStateAsync();

        ShowAuthError = false;
    }
}
