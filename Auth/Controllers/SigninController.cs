using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auth.Controllers
{
    public class SigninController : Controller
    {
        public async Task Index(string redirectUrl)
        {
            string url = null;
            if (!string.IsNullOrWhiteSpace(redirectUrl) && Url.IsLocalUrl(redirectUrl))
            {
                url = redirectUrl;
            }

            url = url ?? Url.Action("Callback", "Signin");
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                // Indicate here where Auth0 should redirect the user after a login.
                // Note that the resulting absolute Uri must be added to the
                // **Allowed Callback URLs** settings for the app.
                .WithRedirectUri(url)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        public async Task<IActionResult> Callback()
        {
            return Redirect("https://localhost:7298");
        }
    }
}
