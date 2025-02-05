namespace MaternityHospital.Api.Models.Pagination;

public class PaginationFilter
{
    public uint PageNumber { get; set; }
    public uint PageSize { get; set; }

    public const int DefaultPageSize = 10;

    public PaginationFilter(bool isDesc = false)
    {
        PageNumber = 1;
        PageSize = DefaultPageSize;
    }

    public PaginationFilter(uint pageNumber, uint pageSize)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize < DefaultPageSize ? DefaultPageSize : pageSize;
    }

    public uint GetSkipCount()
        => (PageNumber - 1) * PageSize;
}
