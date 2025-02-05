using MaternityHospital.Api.Models;
using MongoDB.Driver;

namespace MaternityHospital.Api.Infrastructure;

public interface IPatientContext
{
    IMongoCollection<Patient> Patients { get; }
}
