using MaternityHospital.Api.Middlewares;

namespace MaternityHospital.Api.Configuration.Middlewares;

internal static class MiddlewaresConfiguration
{
    internal static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ErrorHandlerMiddleware>();
}
