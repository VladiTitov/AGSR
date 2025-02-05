using MaternityHospital.Api.Configuration.Services;

namespace MaternityHospital.Api.Configuration.Application;

internal static class ApplicationBuilderConfiguration
{
    internal static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureServices();
        return builder;
    }
}
