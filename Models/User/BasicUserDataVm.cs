namespace TravelPickerApp.Models.User;

public class BasicUserDataVm
{
    public Guid Id { get; set; }
    public string UserName { get; set; }

    public BasicUserDataVm(Guid id, string username)
    {
        this.Id = id;
        this.UserName = username;
    }
}