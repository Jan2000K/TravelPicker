using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.Models.UserControllerModels;

public class AuthorizeBody
{
    [Required]
    public string Username { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}