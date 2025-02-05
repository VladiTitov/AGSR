namespace MaternityHospital.Domain.Wrapper;

#nullable disable
public class Response<T>
{
    public T Data { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; }
    
    public Response() { }

    public Response(string message)
    {
        Succeeded = false;
        Message = message;
    }

    public Response(T data, string message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
}
