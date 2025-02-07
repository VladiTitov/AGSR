namespace MaternityHospital.Api.Models.Pagination;

public class PaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public const int DefaultPageSize = 10;

    public PaginationFilter(PaginationRequest request) 
        : this((int)request.Page, (int)request.Size) { }

    public PaginationFilter(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize < DefaultPageSize ? DefaultPageSize : pageSize;
    }

    public int GetSkipCount()
        => (PageNumber - 1) * PageSize;
}
