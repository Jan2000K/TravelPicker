using Microsoft.AspNetCore.Authentication.Cookies;
using TravelPickerApp.Models;
using TravelPickerApp.Services;
using TravelPickerApp.Services.AppSettingsService;
using TravelPickerApp.Stores;

namespace TravelPickerApp
{
    public static class StartupConfiguration
    {
        public static void ConfigureServices(ref WebApplicationBuilder builder, IConfigurationRoot configRoot)
        {
            builder.Services.AddScoped<LoggerService>();
            builder.Services.AddScoped<ApiCallLoggerService>();
            builder.Services.AddSingleton<AppSettings>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AuthorizationService>();
            builder.Services.AddScoped<GeoSearchService>();
            builder.Services.AddSingleton<CountryCitiesCountStore>();
            builder.Services.AddScoped<LocationService>();
            ConfigureAuthorization(ref builder);
            ConfigureAuthentication(ref builder, new AppSettings(configRoot));
        }

        private static void ConfigureAuthorization(ref WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(AppConstants.AuthPolicies.AdminOnly, policy => policy
                    .RequireRole(AppConstants.UserRoles.Admin.ToString())
                    );
                options.AddPolicy(AppConstants.AuthPolicies.UserOrAbove, policy => policy
                    .RequireRole(AppConstants.UserRoles.User.ToString(), AppConstants.UserRoles.Admin.ToString())

                );
            });
        }

        private static void ConfigureAuthentication(ref WebApplicationBuilder builder, AppSettings appSettings)
        {
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.Cookie.Domain = appSettings.Session.Cookie.Domain;
                    opts.Cookie.IsEssential = true;
                    opts.Cookie.SameSite = appSettings.Session.Cookie.SameSite;
                    opts.Cookie.MaxAge = TimeSpan.FromMinutes(appSettings.Session.Cookie.MaxAgeMinutes);
                    opts.SlidingExpiration = appSettings.Session.Cookie.SlidingExpiration;
                    opts.Cookie.HttpOnly = appSettings.Session.Cookie.HttpOnly;
                    opts.Cookie.Name = appSettings.Session.Cookie.Name;
                    opts.Cookie.SecurePolicy = appSettings.Session.Cookie.SecurePolicy;
                    opts.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return context.Response.CompleteAsync();
                    };
                });
        }
    }
}
