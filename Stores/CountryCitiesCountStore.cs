namespace TravelPickerApp.Stores;

public class CountryCitiesCountStore
{
    private Dictionary<string, int> _countryCitiesResultMaxOffset = new();

    public int? GetCountryCitiesResultCount(string countryCode)
    {
        var exists  =_countryCitiesResultMaxOffset.TryGetValue(countryCode, out var offset);
        if (exists)
        {
            return offset;
        }

        return null;
    }

    public void AddCountryCitiesResultCount(string countryCode, int offset)
    {
        if (_countryCitiesResultMaxOffset.ContainsKey(countryCode))
            return;
        _countryCitiesResultMaxOffset.Add(countryCode, offset);
    }
}