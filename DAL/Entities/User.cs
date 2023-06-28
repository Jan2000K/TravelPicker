using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
     public String Username { get; set; } = String.Empty;
    public String? Email { get; set; }
    [MaxLength(64)] public Byte[] Password { get; set; } = null!;
    public Boolean Active { get; set; }  
    public DateTimeOffset? LastLogin { get; set; }
    public ICollection<UserGroup> UserGroups { get; set; }

    public User()
    {
        UserGroups = new HashSet<UserGroup>();
    }


}