namespace TravelPickerApp.Models.GeoSearch;

public class CitiesResponseVM
{
    public ICollection<CityInstanceVM> Data { get; set; }
    public CityResponseMetadata Metadata { get; set; }
}