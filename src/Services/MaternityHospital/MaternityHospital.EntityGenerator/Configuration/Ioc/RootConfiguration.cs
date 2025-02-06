using MaternityHospital.EntityGenerator.Configuration.Services;

namespace MaternityHospital.EntityGenerator.Configuration.Ioc;

internal static class RootConfiguration
{
    internal static IHostBuilder ConfigureHostBuilder(this IHostBuilder builder)
        => builder
            .ConfigureServices((hostBuilderContext, services) =>
            {
                services.AddServices(hostBuilderContext.Configuration);
                services.AddHostedService<Worker>();
            });
}
