using TravelPickerApp.Models;

namespace TravelPickerApp.Dto.Entities;

public class ApplicationLog
{
    public Guid Id { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
    public ActionStatusCode? ActionStatusCode { get; set; }
    public String LogContent { get; set; }
}