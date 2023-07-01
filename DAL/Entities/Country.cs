using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class Country
{
    public Guid Id { get; set; }
    [MaxLength(2)]
    public String Iso { get; set; }
    [MaxLength(80)]
    public String Name { get; set; }
    [MaxLength(80)]
    public String NiceName { get; set; }
    public String? Iso3 { get; set; } 
    public int? NumCode { get; set; }
    public int PhoneCode { get; set; } 
}