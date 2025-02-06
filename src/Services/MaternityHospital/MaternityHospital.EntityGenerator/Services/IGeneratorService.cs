namespace MaternityHospital.EntityGenerator.Services;

public interface IGeneratorService
{
    IEnumerable<Patient> GetPatientList(int count);
}
