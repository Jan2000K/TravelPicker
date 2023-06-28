using TravelPickerApp.Models;

namespace TravelPickerApp.Models;

public class Result<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public ActionStatusCode Code {  get; set; }
    public Result(ActionStatusCode code,T data,string message)
    {
        this.Code = code;
        this.Data = data;
        this.Message = message;

    }
}