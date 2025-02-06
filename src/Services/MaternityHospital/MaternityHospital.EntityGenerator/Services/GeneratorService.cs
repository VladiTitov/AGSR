using MaternityHospital.EntityGenerator.Fakers;

namespace MaternityHospital.EntityGenerator.Services;

internal class GeneratorService : IGeneratorService
{
    private readonly PatientFaker _patientFaker;

    public GeneratorService()
    {
        _patientFaker = new PatientFaker();
    }

    public IEnumerable<Patient> GetPatientList(int count)
        => _patientFaker.GenerateLazy(count);
}
