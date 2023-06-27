using TravelPickerApp.Models.CityControllerModels;
using TravelPickerApp.Models.GeoSearch;

namespace TravelPickerApp.Mappers;

public static class LocationMapper
{
    public static RandomCityVM MapCityInstanceVmToRandomCityVm(CityInstanceVM cityInstanceVm)
    {
        return new RandomCityVM()
        {
            CityName = cityInstanceVm.City,
            RegionName = cityInstanceVm.Region,
            Latitude = cityInstanceVm.Latitude,
            Longitude = cityInstanceVm.Longitude
        };
    }
}