using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class Location
{
    [Required]
    public Guid Id { get; set; }
    [MaxLength(250)]
    [Required]
    public String LocationName { get; set; } = String.Empty;
    [Required]
    public Decimal Latitude { get; set; }
    public Country Country { get; set; }
    [Required]
    public Decimal Longitude { get; set; } 
    [Required]
    public DateTimeOffset DateAdded { get; set; }
    
}