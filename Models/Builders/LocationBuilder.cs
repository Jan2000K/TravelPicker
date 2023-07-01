using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Exceptions.Location;

namespace TravelPickerApp.Models.Builders;

public class LocationBuilder
{

    private Guid _id;

    private String _locationName= String.Empty;

    private Decimal _latitude;

    private Decimal _longitude;

    private DateTimeOffset _dateCreated;
    private DAL.Entities.User _assignedTo;
    private DAL.Entities.User _createdBy;
    private Country _country;
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
        this._dateCreated = addedAt;
        return this;
    }

    public LocationBuilder AssignedTo(DAL.Entities.User user)
    {
        _assignedTo = user;
        return this;
    }
    public LocationBuilder CreatedBy(DAL.Entities.User user)
    {
        _createdBy = user;
        return this;
    }
    public LocationBuilder WithCountry(Country country)
    {
        _country = country;
        return this;
    }
    public DAL.Entities.Location Build()
    {
        if (_country is null || _longitude == default || _longitude == default || _assignedTo is null ||
            string.IsNullOrEmpty(_locationName) || _createdBy is null)
        {
            throw new LocationBuilderException("Cannot build location as not all required fields are set");
        }
        return new DAL.Entities.Location
        {
            Id = _id,
            LocationName = _locationName,
            Longitude = _longitude,
            Latitude = _latitude,
            DateCreated = _dateCreated,
            AssignedTo = _assignedTo,
            CreatedBy = _createdBy,
        };
    }
}