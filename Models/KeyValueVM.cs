namespace TravelPickerApp.Models;

public class KeyValueVM
{
    public Guid Id { get; set; }
    public String Name { get; set; }

    public KeyValueVM(Guid id, String name)
    {
        Id = id;
        Name = name;
    }
}