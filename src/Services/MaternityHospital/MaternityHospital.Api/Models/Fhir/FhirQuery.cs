namespace MaternityHospital.Api.Models.Fhir;

#nullable disable
public record FhirQuery<T>(FhirOperator Operator, T Value);
