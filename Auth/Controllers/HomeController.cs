using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace Auth.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task Index()
    {
        var x = this.User.Identity.IsAuthenticated;
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            // Indicate here where Auth0 should redirect the user after a login.
            // Note that the resulting absolute Uri must be added to the
            // **Allowed Callback URLs** settings for the app.
            .WithRedirectUri("https://localhost:7174/home/postlogin")
            .Build();

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    }

    public IActionResult PostLogin()
    {
        var x = this.User.Identity.IsAuthenticated;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
