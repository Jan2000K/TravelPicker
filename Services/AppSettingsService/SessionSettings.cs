namespace HttpClientApp.Services.AppSettingsService;


public class SessionSettings
{
    private const string SectionAccessor = "Session";
    private IConfiguration _configuration { get; set; }
    private string _precedingAccessors;
    public CookieSettings Cookie { get; }

    public SessionSettings(IConfiguration configuration, string precedingAccessors)
    {
        this._configuration = configuration;
        this._precedingAccessors = precedingAccessors;
        this.Cookie = new CookieSettings(configuration, $"{_precedingAccessors}{SectionAccessor}:");
    }
}

public class CookieSettings
{
    
    private const string SectionAccessor = "Cookie";
    private IConfiguration _configuration;
    private string _precedingAccessors;
    public string Name
    {
        get => _configuration.GetValue<string>($"{_precedingAccessors}{SectionAccessor}:{nameof(Name)}");
    }
    public string Domain
    {
        get => _configuration.GetValue<string>($"{_precedingAccessors}{SectionAccessor}:{nameof(Domain)}");
    }
    public bool HttpOnly
    {
        get => _configuration.GetValue<bool>($"{_precedingAccessors}{SectionAccessor}:{nameof(HttpOnly)}");
    }
    public SameSiteMode SameSite
    {
        get
        {
            var parsedValue =_configuration.GetValue<string>($"{_precedingAccessors}{SectionAccessor}:{nameof(SameSite)}");
            if (SameSiteMode.TryParse(parsedValue, out SameSiteMode enumValue))
            {
                return enumValue;
            }
            else
            {
                throw new InvalidCastException($"Cannot convert parsed value {parsedValue} into SameSiteMode enum ");
            }
        }
    }

    public Boolean IsEssential
    {
        get=> _configuration.GetValue<Boolean>($"{_precedingAccessors}{SectionAccessor}:{nameof(IsEssential)}");
    }

    public int MaxAgeMinutes
    {
        get=> _configuration.GetValue<int>($"{_precedingAccessors}{SectionAccessor}:{nameof(MaxAgeMinutes)}");
    }

    public bool SlidingExpiration
    {
        get=> _configuration.GetValue<bool>($"{_precedingAccessors}{SectionAccessor}:{nameof(SlidingExpiration)}");
    }

    public CookieSecurePolicy SecurePolicy
    {
        get
        {
            var parsedValue =_configuration.GetValue<string>($"{_precedingAccessors}{SectionAccessor}:{nameof(SecurePolicy)}");
            if (CookieSecurePolicy.TryParse(parsedValue, out CookieSecurePolicy enumValue))
            {
                return enumValue;
            }
            else
            {
                throw new InvalidCastException($"Cannot convert parsed value {parsedValue} into CookiePolicySecure enum ");
            }
        }
    }
    public CookieSettings(IConfiguration configuration,string precedingAccessors)
    {
        this._configuration = configuration;
        this._precedingAccessors = precedingAccessors;
    }
}