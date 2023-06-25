using TravelPickerApp.Models;

namespace TravelPickerApp.Models;

public class Result<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public AppCode Code {  get; set; }
    public Result(AppCode code,T data,string message)
    {
        this.Code = code;
        this.Data = data;
        this.Message = message;

    }
}