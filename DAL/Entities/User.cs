using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class User
{
    [Required] public Guid Id { get; set; } = Guid.NewGuid();
    [Required] public String Username { get; set; } = String.Empty;
    public String? Email { get; set; }
    [Required,MaxLength(64)] public Byte[] Password { get; set; } = null!;
    [Required] public Boolean Active { get; set; }  
    public DateTimeOffset? LastLogin { get; set; }
    public ICollection<UserGroup> UserGroups { get; set; }

    public User()
    {
        UserGroups = new HashSet<UserGroup>();
    }


}