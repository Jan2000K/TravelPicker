using System.Net;

namespace TravelPickerApp.Dto.Entities;

public class BaseApiLog
{
    public Guid Id { get; set; }
    public User RequestedBy { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
    public String? ServiceName { get; set; }
    public String? ServiceMethodName { get; set; }
    public HttpStatusCode? StatusCode { get; set; }
    public String? AdditionalData { get; set; }
}