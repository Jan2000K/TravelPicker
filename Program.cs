using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using TravelPickerApp;
using TravelPickerApp.Dto;
using TravelPickerApp.Dto.Entities;
using TravelPickerApp.Models;
using TravelPickerApp.Services;

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
        options.UseSqlServer(configuration.GetConnectionString("TravelPickerDb"))
    );
    var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer(configuration.GetConnectionString("TravelPickerDb"))
        .Options;
    var dbContext = new AppDbContext(contextOptions);
    var loggerService = new LoggerService(dbContext);
    if (builder.Environment.IsDevelopment())
    {
        try
        {
            var seedService = new SeedingService(loggerService, dbContext);
            await seedService.SeedTestData();
        }
        catch (Exception ex)
        {
            await loggerService.LogExceptionAsync(ex);
        }
    }
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    StartupConfiguration.ConfigureServices(ref builder, configuration);

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
    app.UseAuthentication();
    app.UseAuthorization();

    app.Run();
    dbContext.ApplicationLog.Add(new ApplicationLog
    {
        Id = Guid.NewGuid(),
        ActionStatusCode = ActionStatusCode.ActionSuccess,
        LogContent = "Started web application",
        TimeStamp = DateTimeOffset.UtcNow
    });
    dbContext.SaveChanges();
}
catch (Exception ex)
{
    logger.Error(ex, "Startup failed due to exception");
}
finally
{
    NLog.LogManager.Shutdown();
}