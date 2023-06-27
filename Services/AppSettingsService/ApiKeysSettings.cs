using HttpClientApp.Services.AppSettingsService;

namespace TravelPickerApp.Services.AppSettingsService;

public class ApiKeysSettings
{
    private const string SectionAccessor = "ApiKeys";
    private IConfiguration _configuration { get; set; }
    private readonly string _precedingAccessors;
    public string TomTomKey
    {
        get => _configuration.GetValue<string>($"{_precedingAccessors}{SectionAccessor}:{nameof(TomTomKey)}");
    }

    public ApiKeysSettings(IConfiguration configuration, string precedingAccessors)
    {
        this._configuration = configuration;
        this._precedingAccessors = precedingAccessors;
    }   
}