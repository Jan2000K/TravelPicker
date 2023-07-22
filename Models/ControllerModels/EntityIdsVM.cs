using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.Models.ControllerModels;

public class EntityIdsVM
{
    [Required]
    public ICollection<Guid> EntityIds { get; set; }
}