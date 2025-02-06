using Microsoft.OpenApi.Models;

namespace MaternityHospital.Api.Configuration.Swagger;

internal static class SwaggerConfiguration
{
    internal static IServiceCollection RegisterSwagger(this IServiceCollection services)
        => services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(opt =>
            {
                var basePath = AppContext.BaseDirectory;

                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Maternity hospital api",
                    Description = "Test task for AGSR company"
                });

                var xmlPath = Path.Combine(basePath, "MaternityHospital.Api.xml");
                opt.IncludeXmlComments(xmlPath);
            });

    internal static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        => app
            .UseSwagger()
            .UseSwaggerUI(c => c.SwaggerEndpoint(
                url: "/swagger/v1/swagger.json", 
                name: "v1"));
}
