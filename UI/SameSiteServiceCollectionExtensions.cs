using Auth0.AspNetCore.Authentication;

namespace UI
{
    public static class SameSiteServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureSameSiteNoneCookies(this IServiceCollection services)
        {
            services.AddAuthentication(Auth0Constants.AuthenticationScheme).AddCookie();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                options.OnAppendCookie = cookieContext => CheckSameSite(cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext => CheckSameSite(cookieContext.CookieOptions);
            });

            return services;
        }

        private static void CheckSameSite(CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None && options.Secure == false)
            {
                options.SameSite = SameSiteMode.Unspecified;
            }
        }
    }
}
