using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace UI.Middlewares
{
    public class AuthorizationMiddleware : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();
        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Challenged)
            {
                context.Response.Redirect("https://localhost:7174");
            }
            else
            {
                // Fall back to the default implementation.
                await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
            }
        }
    }
}
