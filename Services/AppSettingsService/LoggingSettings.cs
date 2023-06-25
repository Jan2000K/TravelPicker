using PersonalDashboard.Services.AppSettingsService;

namespace HttpClientApp.Services.AppSettingsService;


public class BaseLogging:IBaseLogging
{
    private const string SectionAccessor = "Logging";
    private IConfiguration _configuration { get; set; }
    private string _precedingAccessors;
    public BaseLogLevel LogLevel { get; }

    public BaseLogging(IConfiguration configuration, string precedingAccessors)
    {
        this._configuration = configuration;
        this._precedingAccessors = precedingAccessors;
        this.LogLevel = new BaseLogLevel(configuration, $"{_precedingAccessors}{SectionAccessor}:");
    }
}

public class BaseLogLevel
{
    
    private const string SectionAccessor = "LogLevel";
    private IConfiguration _configuration;
    private string _precedingAccessors;
    public string Default
    {
        get => _configuration.GetValue<string>($"{_precedingAccessors}{SectionAccessor}:{nameof(Default)}");
    }
    private const string MicrosoftAspNetCoreAccessor = "Microsoft.AspNetCore";
    public string MicrosoftAspNetCore
    {
        get => _configuration.GetValue<string>($"{_precedingAccessors}{SectionAccessor}:{MicrosoftAspNetCoreAccessor}");

    }

    public BaseLogLevel(IConfiguration configuration,string precedingAccessors)
    {
        this._configuration = configuration;
        this._precedingAccessors = precedingAccessors;
    }
}