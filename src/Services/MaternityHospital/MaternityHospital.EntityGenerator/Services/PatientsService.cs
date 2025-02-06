using Refit;
using System.Net;
using Microsoft.Extensions.Options;

namespace MaternityHospital.EntityGenerator.Services;

internal class PatientsService : IPatientsService
{
    private readonly IMaternityHospitalApi _api;

    public PatientsService(
        IOptions<HttpConnectionSettings> options)
    {
        var connection = options.Value
            ?? throw new ArgumentNullException(nameof(options));
        _api = RestService.For<IMaternityHospitalApi>(connection.ToString());
    }

    public async Task<Guid> CreateAsync(
        Patient patient,
        CancellationToken cancellationToken = default)
    {
        using var httpResponseMessage = await _api
            .CreatePatientAsync(patient, cancellationToken);

        if (httpResponseMessage.StatusCode == HttpStatusCode.Created)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
            if (string.IsNullOrEmpty(content)) return default;
            return content.Replace("\"", " ").ToGuid();
        }
        return default;
    }
}
