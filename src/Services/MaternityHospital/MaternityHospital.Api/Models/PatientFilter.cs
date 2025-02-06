using MaternityHospital.Api.Models.Fhir;
using MaternityHospital.Domain.Extensions;

namespace MaternityHospital.Api.Models;

public class PatientFilter : PaginationFilter
{
    public IEnumerable<FhirQueryDateTime>? BirthDate { get; set; }

    public PatientFilter(PatientRequest request) 
        : this((int)request.Page, (int)request.Size, request.BirthDate) { }

    public PatientFilter(
        int pageNumber, int pageSize,
        IEnumerable<string>? birthDate = default) : base(pageNumber, pageSize)
    {
        if (birthDate != null && birthDate.Any())
            BirthDate = birthDate
                .Select(i => new FhirQueryDateTime(i[0..2].ToUpper(), i[2..].ToDateTime()));
    }
}
