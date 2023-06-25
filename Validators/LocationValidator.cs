using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models.Builders;

namespace TravelPickerApp.Validators;

public class LocationValidator : IValidator
{
    public bool IsValid { get; private set; }
    public String ValidationMessage { get; private set; } = String.Empty;
    private Location _entityInstance;

    public LocationValidator WithLocation(Location location)
    {
        _entityInstance = location;
        return this;
    }
    
    
    public bool Validate()
    {
        return false;
    }
    
}