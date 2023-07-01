using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class Location:EntityMetadata
{
    public Guid Id { get; set; }
    [MaxLength(250)]
    public String LocationName { get; set; } = String.Empty;
    public Decimal Latitude { get; set; }

    public Country Country { get; set; } = default!;
    public Decimal Longitude { get; set; } 
    public virtual User AssignedTo { get; set; }
    
}