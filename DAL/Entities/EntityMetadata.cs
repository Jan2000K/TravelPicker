namespace TravelPickerApp.DAL.Entities;

public class EntityMetadata
{
    public User CreatedBy { get; set; } = default!;
    public DateTimeOffset DateCreated { get; set; }
}