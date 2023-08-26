
using HttpClientApp.Services.AppSettingsService;

namespace TravelPickerApp.Services.AppSettingsService;

public class AppSettings : IAppSettings
{
    private const string SectionAccessor = "";
    public BaseLogging Logging { get; }
    public SessionSettings Session { get; }

    public AppSettings(IConfiguration configuration)
    {

        this.Logging = new BaseLogging(configuration, SectionAccessor);
        this.Session = new SessionSettings(configuration, SectionAccessor);
    }
}

