using HttpClientApp.Services.AppSettingsService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using NLog;
using NLog.Web;
using TravelPickerApp.DAL;
using TravelPickerApp.Models;
using TravelPickerApp.Services;
using TravelPickerApp.Services.AppSettingsService;
using TravelPickerApp.Stores;

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);
    IConfigurationRoot? configuration = null;
    if (builder.Environment.IsDevelopment())
    {
        configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json")
            .AddEnvironmentVariables()
            .Build();
        
    }
    else
    {
        configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("PersonalDashboardDb"))
    );
    var appSettings = new AppSettings(configuration);
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddScoped<LoggerService>();
    builder.Services.AddScoped<ApiCallLoggerService>();
    builder.Services.AddSingleton<AppSettings>();
    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<AuthorizationService>();
    builder.Services.AddScoped<GeoSearchService>();
    builder.Services.AddSingleton<CountryCitiesCountStore>();
    
    builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(AppConstants.AuthPolicies.AdminOnly, policy => policy
                .RequireRole(AppConstants.UserRoles.Admin.ToString())
                .RequireAuthenticatedUser());
            options.AddPolicy(AppConstants.AuthPolicies.UserOrAbove,policy => policy
                .RequireRole(AppConstants.UserRoles.Admin.ToString(),AppConstants.UserRoles.User.ToString())
                .RequireAuthenticatedUser());
        }
    );
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

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddLogging();
    builder.Services.AddEntityFrameworkSqlServer();
    builder.Services.AddAntiforgery();


    builder.Services.AddControllers();
    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors(builder =>
        {
            builder.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:5173")
                .AllowCredentials()
                .Build();
        });
    }
    app.UseHttpsRedirection();
    
    app.MapControllers();
    app.UseAuthorization();
    app.UseAuthentication();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Startup failed due to exception");
}
finally
{
    NLog.LogManager.Shutdown();
}