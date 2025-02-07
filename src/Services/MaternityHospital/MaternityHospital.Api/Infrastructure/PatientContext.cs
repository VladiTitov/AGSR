using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MaternityHospital.Api.Infrastructure;

internal class PatientContext : IPatientContext, IDisposable
{
    private readonly MongoDbConnection _connection;
    private readonly IMongoClient _mongoClient;

    public IMongoCollection<Patient> Patients 
        => _mongoClient
            .GetDatabase(_connection.DatabaseName)
            .GetCollection<Patient>(nameof(Patient));

    public PatientContext(IOptions<MongoDbConnection> options)
    {
        _connection = options.Value 
            ?? throw new ArgumentNullException(nameof(MongoDbConnection));
        _mongoClient = new MongoClient(_connection.ToString());
    }

    public void Dispose()
        => _mongoClient.Dispose();
}
