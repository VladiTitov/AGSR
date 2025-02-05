using MaternityHospital.Api.Configuration.Swagger;

namespace MaternityHospital.Api.Configuration.Application;

internal static class ApplicationConfiguration
{
    internal static WebApplication ConfigureWebApplication(this WebApplication application)
    {
        if (!application.Environment.IsProduction())
        {
            application.UseDeveloperExceptionPage();
            application.ConfigureSwagger();
        }

        application.UseAuthorization();
        application.MapControllers();

        return application;
    }
}
