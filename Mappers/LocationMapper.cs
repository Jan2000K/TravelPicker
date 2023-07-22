using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;
using TravelPickerApp.Models.GeoSearch;
using TravelPickerApp.Models.Location;

namespace TravelPickerApp.Mappers;

public static class LocationMapper
{
    
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