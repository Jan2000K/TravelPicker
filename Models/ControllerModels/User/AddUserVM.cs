using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.Models.ControllerModels.Users;

public class AddUserVM
{
    [Required]
    public string Username { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;

    public ICollection<Guid> UserGroups = new Collection<Guid>();
    public string? Email { get; set; } 
    
}