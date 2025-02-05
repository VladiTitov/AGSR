using MaternityHospital.Api.Configuration.Swagger;
using MaternityHospital.Api.Mappings;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.Conventions;
using System.Reflection;
using System.Text.Json.Serialization;
using MaternityHospital.Api.Behaviors;
using FluentValidation;

namespace MaternityHospital.Api.Configuration.Services;

internal static class ServicesConfiguration
{
    internal static IServiceCollection ConfigureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidation();
        services
            .AddControllers()
            .AddJsonOptions(opt => 
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        services.RegisterSwagger();
        services.AddAutoMapper(cfg => cfg.AddProfile(new PatientProfile()));
        services.AddPersistenceInfrastructure(opt => 
            configuration.GetRequiredSection(nameof(MongoDbConnection))
            .Bind(opt));
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

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

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
