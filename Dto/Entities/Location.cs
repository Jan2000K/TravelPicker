using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.Dto.Entities;

public class Location : EntityMetadata
{
    public Guid Id { get; set; }
    [MaxLength(250)]
    public String LocationName { get; set; } = String.Empty;
    public Decimal Latitude { get; set; }

    public Country Country { get; set; } = default!;
    public Decimal Longitude { get; set; }
    public String? RegionName { get; set; }
    public virtual User AssignedTo { get; set; }

}