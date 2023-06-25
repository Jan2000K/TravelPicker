using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class UserGroup
{   
    [Required] public Guid Id { get; set; } = Guid.NewGuid();
    [Required] public String Name { get; set; } = String.Empty;
    [Required] public ICollection<User> Users { get; set; } 
    public UserGroup()
    {
        Users = new HashSet<User>();
    }

}