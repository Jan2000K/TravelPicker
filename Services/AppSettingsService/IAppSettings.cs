namespace HttpClientApp.Services.AppSettingsService;

public interface IAppSettings
{
    public BaseLogging Logging { get; }
    public SessionSettings Session { get; }
}