using TravelPickerApp.DAL.Entities;

namespace TravelPickerApp.Models.Builders;

public class LocationBuilder
{

    private Guid _id { get; set; }

    private String _locationName { get; set; } = String.Empty;

    private Decimal _latitude { get; set; }

    private Decimal _longitude { get; set; } 

    private DateTimeOffset _dateAdded { get; set; }
    public LocationBuilder WithId(Guid Id)
    {
        this._id  = Id;
        return this;
    }
    public LocationBuilder WithName(string name)
    {
        this._locationName = name;
        return this;
    }

    public LocationBuilder WithLatitude(Decimal Latitude)
    {
        this._latitude = Latitude;
        return this;
    }

    public LocationBuilder WithLongitude(Decimal Longitude)
    {
        this._longitude = Longitude;
        return this;
    }

    public LocationBuilder AddedAt(DateTimeOffset addedAt)
    {
        this._dateAdded = addedAt;
        return this;
    }

    public Location Build()
    {
        return new Location
        {
            Id = _id,
            LocationName = _locationName,
            Longitude = _longitude,
            Latitude = _latitude,
            DateAdded = _dateAdded
        };
    }
}