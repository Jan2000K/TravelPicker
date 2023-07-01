using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.Models.ControllerModels.Location;

public class EditLocationVM:AddLocationVM
{
    [Required]
    public Guid Id { get; set; }
}