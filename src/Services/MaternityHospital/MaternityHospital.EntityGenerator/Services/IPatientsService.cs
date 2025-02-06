namespace MaternityHospital.EntityGenerator.Services;

public interface IPatientsService
{
    Task<Guid> CreateAsync(Patient patient, CancellationToken cancellationToken = default);
}
