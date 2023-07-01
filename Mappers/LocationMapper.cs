using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;
using TravelPickerApp.Models.City;
using TravelPickerApp.Models.GeoSearch;
using TravelPickerApp.Models.Location;

namespace TravelPickerApp.Mappers;

public static class LocationMapper
{
    public static CityVM MapCityInstanceVmToRandomCityVm(CityInstanceVM cityInstanceVm)
    {
        return new CityVM 
        {
            CityName = cityInstanceVm.City,
            RegionName = cityInstanceVm.Region,
            Latitude = cityInstanceVm.Latitude,
            Longitude = cityInstanceVm.Longitude,
            CountryCode = cityInstanceVm.CountryCode
        };
    }

    public static LocationVM MapLocationToLocationVm(Location locationInstance)
    {
        return new LocationVM
        {
            Id = locationInstance.Id,
            Latitude = locationInstance.Latitude,
            Longitude = locationInstance.Longitude,
            Country = new KeyValueVM<string,string>(locationInstance.Country.Iso, locationInstance.Country.NiceName),
            DateCreated = locationInstance.DateCreated,
            LocationName = locationInstance.LocationName
        };
    }
}