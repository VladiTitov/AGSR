namespace MaternityHospital.Domain.Wrapper;

#nullable disable
public class PagedResponse<T> : Response<T>
{
    public uint PageNumber { get; set; }
    public uint PageSize { get; set; }

    public PagedResponse(T data, uint pageNumber, uint pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Data = data;
        Message = null;
        Succeeded = true;
        Errors = null;
    }
}
