using FluentValidation;
using System.Net;
using System.Text.Json;

namespace MaternityHospital.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>()
            {
                Succeeded = false,
                Message = error?.Message
            };

            switch (error)
            {
                case ValidationException ex:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = ex.Errors.Select(_ => _.ErrorMessage);
                    break;
                case InvalidCastException ex:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var responseMessage = JsonSerializer.Serialize(responseModel, serializeOptions);
            await response.WriteAsync(responseMessage);
        }
    }
}
