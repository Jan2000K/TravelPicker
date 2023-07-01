using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class UserGroup
{   
    public Guid Id { get; set; } = Guid.NewGuid();
    public String Name { get; set; } = String.Empty;
    public virtual ICollection<User> Users { get; set; } 
    public UserGroup()
    {
        Users = new HashSet<User>();
    }

}