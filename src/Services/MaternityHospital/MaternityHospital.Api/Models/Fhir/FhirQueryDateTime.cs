using MaternityHospital.Domain.Extensions;

namespace MaternityHospital.Api.Models.Fhir;

public record FhirQueryDateTime : FhirQuery<DateTime>
{
    public FhirQueryDateTime(string op, DateTime value) : base(op.ToEnum<FhirOperator>(), value)
    {
        
    }
}
