using TravelPickerApp.Validators;

namespace TravelPickerApp.Services;

public class CountryValidator:IValidator
{
    public bool IsValid { get; private set; }
    public string ValidationMessage { get; private set; }
    public bool Validate()
    {
        throw new NotImplementedException();
    }
}