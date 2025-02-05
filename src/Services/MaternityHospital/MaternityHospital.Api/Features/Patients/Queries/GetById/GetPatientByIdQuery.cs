namespace MaternityHospital.Api.Features.Patients.Queries.GetById;

public record GetPatientByIdQuery(Guid Id) : IRequest<Patient>;
