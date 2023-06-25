namespace TravelPickerApp.Validators;

public interface IValidator
{
      bool IsValid { get; }
      String ValidationMessage { get; }
      bool Validate();

}