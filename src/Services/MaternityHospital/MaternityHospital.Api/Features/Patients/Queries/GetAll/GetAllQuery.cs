namespace MaternityHospital.Api.Features.Patients.Queries.GetAll;

public record GetAllQuery(PaginationFilter Filter) : IRequest<List<Patient>>;
