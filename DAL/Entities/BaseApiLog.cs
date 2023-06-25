using System.ComponentModel.DataAnnotations;

namespace TravelPickerApp.DAL.Entities;

public class BaseApiLog
{
    [Required] Guid Id { get; set; }
    [Required] User RequestedBy { get; set; }
    [Required] DateTimeOffset RequestTime { get; set; }
    String? ServiceName { get; set; } 
    String? ServiceMethodName { get; set; } 
}