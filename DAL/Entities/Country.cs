using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class Country
{
    [Required]
    public int Id { get; set; }
    [Required,MaxLength(2)]
    public String Iso { get; set; }
    [Required,MaxLength(80)]
    public String Name { get; set; }
    [MaxLength(80)]
    public String NiceName { get; set; }
    public String? Iso3 { get; set; } 
    public int? NumCode { get; set; }
    [Required]
    public int PhoneCode { get; set; } 
}