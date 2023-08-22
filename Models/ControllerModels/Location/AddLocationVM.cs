using System.ComponentModel.DataAnnotations;


namespace TravelPickerApp.Models.ControllerModels.Location;

public class AddLocationVM
{
    [MaxLength(250)]
    [Required]
    public String LocationName { get; set; } = default!;
    [Required]
    public Decimal Latitude { get; set; }
    [Required]
    public String CountryCode { get; set; }
    [Required]
    public Decimal Longitude { get; set; }
    public String? RegionName { get; set; }
}