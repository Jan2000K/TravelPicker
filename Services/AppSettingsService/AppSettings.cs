
using HttpClientApp.Services.AppSettingsService;

namespace TravelPickerApp.Services.AppSettingsService;

public class AppSettings:IAppSettings
{
    private const string SectionAccessor = "";
    private IConfiguration _configuration;
    public BaseLogging Logging { get; }
    public SessionSettings Session { get; }
    public ApiKeysSettings ApiKeys { get; }
    
    public AppSettings(IConfiguration configuration)
    {
        this._configuration = configuration;
        this.Logging = new BaseLogging(configuration, SectionAccessor);
        this.Session = new SessionSettings(configuration, SectionAccessor);
        this.ApiKeys = new ApiKeysSettings(configuration, SectionAccessor);
    }
}

