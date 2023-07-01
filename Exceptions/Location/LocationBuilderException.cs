namespace TravelPickerApp.Exceptions.Location;

public class LocationBuilderException : Exception
{
    public LocationBuilderException()
    {
    }

    public LocationBuilderException(string message)
        : base(message)
    {
    }

    public LocationBuilderException(string message, Exception inner)
        : base(message, inner)
    {
    }
}