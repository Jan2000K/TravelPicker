using System.Security.Claims;
using TravelPickerApp.DAL;
using TravelPickerApp.Mappers;
using TravelPickerApp.Models;
using TravelPickerApp.Models.CityControllerModels;
using TravelPickerApp.Models.GeoSearch;
using TravelPickerApp.Stores;

namespace TravelPickerApp.Services;

public class GeoSearchService
{
    private readonly AppDbContext _dbContext;
    private readonly CountryCitiesCountStore _countryCitiesCountStore;
    private readonly LoggerService _logger;
    private readonly ApiCallLoggerService _apiCallLogger;
    private readonly UserService _userService;

    public GeoSearchService(AppDbContext dbContext,CountryCitiesCountStore countryCitiesCountStore,LoggerService logger,ApiCallLoggerService apiCallLogger,UserService userService)
    {
        _dbContext = dbContext;
        _countryCitiesCountStore = countryCitiesCountStore;
        _logger = logger;
        _apiCallLogger = apiCallLogger;
        _userService = userService;

    }

    public async Task<Result<RandomCityVM>> GetRandomCityInCountry(string countryCode,ClaimsPrincipal user)
    {
        var userId = await _userService.GetUserIdFromClaimsPrincipal(user);
        if (userId is null)
        {
            return new Result<RandomCityVM>(ActionStatusCode.UnexpectedError,null,"Error parsing user data, contact the system administrator");
        }
        if (Validators.CountryValidator.CountryCodeExists(countryCode, _dbContext))
        {
            await _logger.LogInformation($"Could not find country with ISO2 code : {countryCode}",ActionStatusCode.ActionFailed);
            return new Result<RandomCityVM>(ActionStatusCode.ActionFailed, null,
                $"Country code {countryCode} not found in ISO2 standard");
           
        }

        var maxResultCount = _countryCitiesCountStore.GetCountryCitiesResultCount(countryCode);
        var httpClient = new HttpClient();
        var requestUri =
            new Uri(
                $"http://geodb-free-service.wirefreethought.com/v1/geo/cities?types=CITY&countryIds={countryCode}&limit=1");
        if (maxResultCount is null)
        {

            var res = await httpClient.GetAsync(requestUri);
            if (!res.IsSuccessStatusCode)
            {
                await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCityInCountry),
                    res.StatusCode);
                return new Result<RandomCityVM>(ActionStatusCode.UnexpectedError, null, "Failed fetching cities");
                
            }

            var content = await res.Content.ReadFromJsonAsync<CitiesResponseVM>();
            if (content is null)
            {
                await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCityInCountry),
                    res.StatusCode,"Reading content from JSON returns null");
                return new Result<RandomCityVM>(ActionStatusCode.UnexpectedError, null, "Failed fetching cities");
            }

            if (!content.Data.Any())
            {
                return new Result<RandomCityVM>(ActionStatusCode.ActionFailed, null,
                    $"Unable to find any cities for country code {countryCode}");
            }
            _countryCitiesCountStore.AddCountryCitiesResultCount(countryCode,content.Metadata.TotalCount);
            var randomCity = content.Data.ElementAt(0);
            await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCityInCountry),
                res.StatusCode);
            return new Result<RandomCityVM>(ActionStatusCode.ActionSuccess,LocationMapper.MapCityInstanceVmToRandomCityVm(randomCity),"Successfully fetched random city");
        }

        requestUri = new Uri(requestUri + "&offset=" + GetRandomOffset((int)maxResultCount));
        var response = await httpClient.GetAsync(requestUri);
        if (!response.IsSuccessStatusCode)
        {
            await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCityInCountry),
                response.StatusCode);
            return new Result<RandomCityVM>(ActionStatusCode.UnexpectedError, null, "Failed fetching cities");
        }
        var responseContent = await response.Content.ReadFromJsonAsync<CitiesResponseVM>();
        if (responseContent is null)
        {
            await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCityInCountry),
                response.StatusCode,"Reading content from JSON returns null");
            return new Result<RandomCityVM>(ActionStatusCode.UnexpectedError, null, "Failed fetching cities");
        }

        if (!responseContent.Data.Any())
        {
            return new Result<RandomCityVM>(ActionStatusCode.ActionFailed, null,
                $"Unable to find any cities for country code {countryCode}");
        }
        _countryCitiesCountStore.AddCountryCitiesResultCount(countryCode,responseContent.Metadata.TotalCount);
        var randomCity2 = responseContent.Data.ElementAt(0);
        await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCityInCountry),
            response.StatusCode);
        return new Result<RandomCityVM>(ActionStatusCode.ActionSuccess,LocationMapper.MapCityInstanceVmToRandomCityVm(randomCity2),"Successfully fetched random city");
    }

    private int GetRandomOffset(int totalResultCount)
    {

        return new Random().Next(0, totalResultCount);
    }


    
}