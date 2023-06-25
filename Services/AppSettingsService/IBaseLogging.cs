using HttpClientApp.Services.AppSettingsService;

namespace PersonalDashboard.Services.AppSettingsService;

public interface IBaseLogging
{
    public BaseLogLevel LogLevel { get; }
}