using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;
using TravelPickerApp.Models.ControllerModels.City;
using TravelPickerApp.Models.GeoSearch;
using TravelPickerApp.Models.Location;

namespace TravelPickerApp.Mappers;

public static class LocationMapper
{
    public static RandomCityVM MapCityInstanceVmToRandomCityVm(CityInstanceVM cityInstanceVm)
    {
        return new RandomCityVM 
        {
            CityName = cityInstanceVm.City,
            RegionName = cityInstanceVm.Region,
            Latitude = cityInstanceVm.Latitude,
            Longitude = cityInstanceVm.Longitude
        };
    }

    public static LocationVM MapLocationToLocationVm(Location locationInstance)
    {
        return new LocationVM
        {
            Id = locationInstance.Id,
            Latitude = locationInstance.Latitude,
            Longitude = locationInstance.Longitude,
            Country = new KeyValueVM(locationInstance.Country.Id, locationInstance.Country.NiceName),
            DateCreated = locationInstance.DateCreated,
            LocationName = locationInstance.LocationName
        };
    }
}