using TravelPickerApp.Models.Location;

namespace TravelPickerApp.Models.ControllerModels.City;

public class RandomCityFilterVM
{
    public LocationContinent[]? Continents { get; set; }
    public String? CountryCode { get; set; }
    //more filters in the future
}