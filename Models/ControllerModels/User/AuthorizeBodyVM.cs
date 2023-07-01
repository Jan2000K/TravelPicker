using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.Models.ControllerModels.Users;

public class AuthorizeBodyVM
{
    [Required]
    public string Username { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}