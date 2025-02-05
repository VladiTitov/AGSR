namespace MaternityHospital.Api.Configuration.Swagger;

internal static class SwaggerConfiguration
{
    internal static IServiceCollection RegisterSwagger(this IServiceCollection services)
        => services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

    internal static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        => app
            .UseSwagger()
            .UseSwaggerUI(c => c.SwaggerEndpoint(
                url: "/swagger/v1/swagger.json", 
                name: "MaternityHospital.Api"));
}
