namespace MaternityHospital.Api.Models.Fhir;

public record FhirQueryDateTime : FhirQuery<DateTime>
{
    public FhirQueryDateTime(FhirOperator op, DateTime value) 
        : base(op, value) { }

    public bool IsDateOnly() 
        => Value.Hour == 0 && Value.Minute == 0 && Value.Second == 0;
}
