using TravelPickerApp.DAL;
using TravelPickerApp.Mappers;
using TravelPickerApp.Models;
using TravelPickerApp.Models.CityControllerModels;
using TravelPickerApp.Models.GeoSearch;
using TravelPickerApp.Services.AppSettingsService;
using TravelPickerApp.Stores;

namespace TravelPickerApp.Services;

public class GeoSearchService
{
    private readonly AppDbContext _dbContext;
    private readonly CountryCitiesCountStore _countryCitiesCountStore;
    

    public GeoSearchService(AppDbContext dbContext,CountryCitiesCountStore countryCitiesCountStore)
    {
        _dbContext = dbContext;
        _countryCitiesCountStore = countryCitiesCountStore;
    }

    public async Task<Result<RandomCityVM>> GetRandomCityInCountry(string countryCode)
    {
        if (!await Validators.CountryValidator.CountryCodeExists(countryCode, _dbContext))
        {
            return new Result<RandomCityVM>(AppCode.ActionFailed, null,
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
            var content = await res.Content.ReadFromJsonAsync<CitiesResponseVM>();
            if (content is null)
            {
                return new Result<RandomCityVM>(AppCode.UnexpectedError, null, "Failed fetching cities");
            }

            if (!content.Data.Any())
            {
                return new Result<RandomCityVM>(AppCode.ActionFailed, null,
                    $"Unable to find any cities for country code {countryCode}");
            }
            _countryCitiesCountStore.AddCountryCitiesResultCount(countryCode,content.Metadata.TotalCount);
            var randomCity = content.Data.ElementAt(0);
            return new Result<RandomCityVM>(AppCode.ActionSuccess,LocationMapper.MapCityInstanceVmToRandomCityVm(randomCity),"Successfully fetched random city");
        }

        requestUri = new Uri(requestUri + "&offset=" + GetRandomOffset((int)maxResultCount));
        var response = await httpClient.GetAsync(requestUri);
        var responseContent = await response.Content.ReadFromJsonAsync<CitiesResponseVM>();
        if (responseContent is null)
        {
            return new Result<RandomCityVM>(AppCode.UnexpectedError, null, "Failed fetching cities");
        }

        if (!responseContent.Data.Any())
        {
            return new Result<RandomCityVM>(AppCode.ActionFailed, null,
                $"Unable to find any cities for country code {countryCode}");
        }
        _countryCitiesCountStore.AddCountryCitiesResultCount(countryCode,responseContent.Metadata.TotalCount);
        var randomCity2 = responseContent.Data.ElementAt(0);
        return new Result<RandomCityVM>(AppCode.ActionSuccess,LocationMapper.MapCityInstanceVmToRandomCityVm(randomCity2),"Successfully fetched random city");
    }

    private int GetRandomOffset(int totalResultCount)
    {

        return new Random().Next(0, totalResultCount);
    }


    
}