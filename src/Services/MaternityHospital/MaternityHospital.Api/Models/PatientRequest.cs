namespace MaternityHospital.Api.Models;

public class PatientRequest : PaginationRequest
{
    public IEnumerable<string>? BirthDate { get; set; }
}
