using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TravelPickerApp.DAL;
using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;
using TravelPickerApp.Models.ControllerModels.City;
using TravelPickerApp.Models.GeoSearch;
using TravelPickerApp.Models.Location;
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

    public async Task<Result<LocationVM>> GetRandomCity(RandomCityFilterVM filter,ClaimsPrincipal user)
    {
        var userId = await _userService.GetUserIdFromClaimsPrincipal(user);
        if (userId is null)
        {
            return new Result<LocationVM>(ActionStatusCode.UnexpectedError,null,"Error parsing user data, contact the system administrator");
        }

        var countryCode = "";
        if (filter.Continents is null)
        {
            countryCode = filter.CountryCode;
        }
        else if(filter.Continents is not null)
        {
            var result = await GetRandomCountry(filter.Continents);
            if (result.Code != ActionStatusCode.ActionSuccess)
            {
                return new Result<LocationVM>(result.Code, null, result.Message);
            }
            countryCode = result.Data.Iso;
        }
        else
        {
            return new Result<LocationVM>(ActionStatusCode.ActionFailed, null, "Supplied location filter is not valid");
        }
        if (!Validators.CountryValidator.CountryCodeExists(countryCode, _dbContext))
        {
            await _logger.LogInformationAsync($"Could not find country with ISO2 code : {countryCode}",ActionStatusCode.ActionFailed);
            return new Result<LocationVM>(ActionStatusCode.ActionFailed, null,
                $"Country code {countryCode} not found in ISO2 standard");
           
        }

        var maxResultCount = _countryCitiesCountStore.GetCountryCitiesResultCount(countryCode);
        var httpClient = new HttpClient();
        var requestUri =
            new Uri(
                $"http://geodb-free-service.wirefreethought.com/v1/geo/places?types=CITY&countryIds={countryCode}&limit=1");
        if (maxResultCount is null)
        {

            var res = await httpClient.GetAsync(requestUri);
            if (!res.IsSuccessStatusCode)
            {
                await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCity),
                    res.StatusCode,requestUri.ToString());    
                return new Result<LocationVM>(ActionStatusCode.UnexpectedError, null, "Failed fetching cities");
                
            }

            var content = await res.Content.ReadFromJsonAsync<CitiesResponseVM>();
            if (content is null)
            {
                await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCity),
                    res.StatusCode,"Reading content from JSON returns null with uri "+requestUri.ToString());
                return new Result<LocationVM>(ActionStatusCode.UnexpectedError, null, "No cities found for given country");
            }

            if (!content.Data.Any())
            {
                return new Result<LocationVM>(ActionStatusCode.ActionFailed, null,
                    $"Unable to find any cities for country code {countryCode}");
            }
            _countryCitiesCountStore.AddCountryCitiesResultCount(countryCode,content.Metadata.TotalCount);
            var randomCity = content.Data.ElementAt(0);
            await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCity),
                res.StatusCode);
            return new Result<LocationVM>(ActionStatusCode.ActionSuccess, new LocationVM
                {
                    LocationName = randomCity.Name,
                    Country = new KeyValueVM<string, string>(randomCity.CountryCode,randomCity.Country),
                    Latitude = randomCity.Latitude,
                    Longitude = randomCity.Longitude,
                    RegionName = randomCity.Region
                }
                ,"Successfully fetched random city");
        }
        else
        {
            requestUri = new Uri(requestUri + "&offset=" + GetRandomOffset((int)maxResultCount));
            var res = await httpClient.GetAsync(requestUri);
            if (!res.IsSuccessStatusCode)
            {
                await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCity),
                    res.StatusCode,requestUri.ToString());
                return new Result<LocationVM>(ActionStatusCode.UnexpectedError, null, "Failed fetching cities");
            }

            var content = await res.Content.ReadFromJsonAsync<CitiesResponseVM>();
            if (content is null)
            {
                await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCity),
                    res.StatusCode, "Reading content from JSON returns null");
                return new Result<LocationVM>(ActionStatusCode.UnexpectedError, null, "Failed fetching cities with uri "+requestUri.ToString() );
            }

            if (!content.Data.Any())
            {
                return new Result<LocationVM>(ActionStatusCode.ActionFailed, null,
                    $"Unable to find any cities for country code {countryCode}");
            }

            _countryCitiesCountStore.AddCountryCitiesResultCount(countryCode, content.Metadata.TotalCount);
            var randomCity = content.Data.ElementAt(0);
            await _apiCallLogger.LogApiCall((Guid)userId, nameof(GeoSearchService), nameof(GetRandomCity),
                res.StatusCode);
            return new Result<LocationVM>(ActionStatusCode.ActionSuccess,
                new LocationVM
                {
                    LocationName = randomCity.Name,
                    Country = new KeyValueVM<string, string>(randomCity.CountryCode,randomCity.Country),
                    Latitude = randomCity.Latitude,
                    Longitude = randomCity.Longitude,
                    RegionName = randomCity.Region
                }, "Successfully fetched random city");
        }
    }

    public async Task<Result<Country>> GetRandomCountry(LocationContinent[] includedContinents)
    {
        var searchByCountryPhoneCodes = new List<int>();
        foreach (var includedContinent in includedContinents)
        {
            switch (includedContinent)
            {
                case LocationContinent.Europe:
                    searchByCountryPhoneCodes.AddRange(AppConstants.ContinentCountryPhoneCodes.Europe);
                    break;
                default:
                    searchByCountryPhoneCodes.AddRange(AppConstants.ContinentCountryPhoneCodes.Europe); //placeholder as for now only european countries are supported
                    break;
            }
        }

        var randomPick = new Random().Next(0, searchByCountryPhoneCodes.Count);
        var pickedCode = searchByCountryPhoneCodes.ElementAt(randomPick);
        var country = await _dbContext.Countries
            .Where(x => x.PhoneCode == pickedCode)
            .FirstOrDefaultAsync();
        if (country is null)
        {
            await _logger.LogInformationAsync($"Cannot find country in database with phone code : {pickedCode}",ActionStatusCode.UnexpectedError);
            return new Result<Country>(ActionStatusCode.UnexpectedError, null,
                $"Error occured while fetching random country");
        }

        return new Result<Country>(ActionStatusCode.ActionSuccess, country, "Successfully fetched random country");
    }

    private int GetRandomOffset(int totalResultCount)
    {
        return new Random().Next(0, totalResultCount);
    }


    
}