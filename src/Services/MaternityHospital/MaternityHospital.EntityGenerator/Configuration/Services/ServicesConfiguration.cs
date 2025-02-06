using MaternityHospital.EntityGenerator.Services;
using Refit;

namespace MaternityHospital.EntityGenerator.Configuration.Services;

internal static class ServicesConfiguration
{
    internal static IServiceCollection AddServices(
        this IServiceCollection services, IConfiguration configuration)
        => services
            .AddRefitClient<IMaternityHospitalApi, HttpConnectionSettings>(configuration)
            .AddScoped<IGeneratorService, GeneratorService>()
            .AddScoped<IPatientsService, PatientsService>();

    private static IServiceCollection AddRefitClient<TClient, TConfiguration>(
        this IServiceCollection services, IConfiguration configuration)
        where TClient : class
        where TConfiguration : HttpConnectionSettings
    {
        services.Configure<TConfiguration>(configuration.GetRequiredSection(typeof(TConfiguration).Name));
        services.AddRefitClient<TClient>();
        return services;
    }
}
