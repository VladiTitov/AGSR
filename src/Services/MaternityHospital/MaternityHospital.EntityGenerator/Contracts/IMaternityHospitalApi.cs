using MaternityHospital.EntityGenerator.Constants;
using Refit;

namespace MaternityHospital.EntityGenerator.Contracts;

public interface IMaternityHospitalApi
{
    [Post(EndpointsRoutes.Patients)]
    Task<HttpResponseMessage> CreatePatientAsync(
        Patient patient,
        CancellationToken cancellationToken = default);
}
