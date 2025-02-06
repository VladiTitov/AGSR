namespace MaternityHospital.Api.Models.Pagination;

public class PaginationRequest
{
    public uint Page { get; set; } = 1;
    public uint Size { get; set; } = 10;
}
