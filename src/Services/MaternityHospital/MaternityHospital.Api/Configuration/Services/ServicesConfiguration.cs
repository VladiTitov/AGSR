using MaternityHospital.Api.Configuration.Swagger;

namespace MaternityHospital.Api.Configuration.Services;

internal static class ServicesConfiguration
{
    internal static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.RegisterSwagger();

        return services;
    }

    private static IServiceCollection AddPersistenceInfrastructure(
        this IServiceCollection services,
        Action<MongoDbConnection> connection)
    {
        var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("camelCase", conventionPack, t => true);
        BsonSerializer.TryRegisterSerializer(new GuidSerializer(MongoDB.Bson.GuidRepresentation.Standard));

        return services
            .Configure(connection)
            .AddScoped<IPatientContext, PatientContext>();
    }
}
