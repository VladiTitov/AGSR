using MaternityHospital.Api.Configuration.Swagger;

namespace MaternityHospital.Api.Configuration.Services;

internal static class ServicesConfiguration
{
    internal static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services
            .RegisterSwagger();
}
