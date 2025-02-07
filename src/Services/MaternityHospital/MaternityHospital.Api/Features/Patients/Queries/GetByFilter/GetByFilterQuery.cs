namespace MaternityHospital.Api.Features.Patients.Queries.GetByFilter;

public record GetByFilterQuery(PatientFilter Filter) : IRequest<List<Patient>>;
