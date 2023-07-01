namespace TravelPickerApp.Models;

public class KeyValueVM<T,U>
{
    public T Id { get; set; }
    public U Name { get; set; }

    public KeyValueVM(T id,U name)
    {
        Id = id;
        Name = name;
    }
}