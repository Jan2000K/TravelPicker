namespace TravelPickerApp.Models.GeoSearch;

public class CityInstanceVM
{
    public int Id { get; set; }
    public string WikiDataId { get; set; }
    public string Type { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string CountryCode { get; set; }
    public string Region { get; set; }
    public string RegionCode { get; set; }
    public string RegionWdId { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int Population { get; set; }
}