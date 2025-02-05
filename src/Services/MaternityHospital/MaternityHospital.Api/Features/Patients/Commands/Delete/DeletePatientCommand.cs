namespace MaternityHospital.Api.Features.Patients.Commands.Delete;

public record DeletePatientCommand(Guid Id) : IRequest<bool>;
