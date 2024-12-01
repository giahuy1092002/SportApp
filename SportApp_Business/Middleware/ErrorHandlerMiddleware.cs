using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Security;
using SportApp_Infrastructure;
using System.Net;
using System.Text.Json;

namespace SportApp_Business.Middleware
{
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

                response.StatusCode = error switch
                {
                    AppException => (int)HttpStatusCode.BadRequest,
                    MissingFieldException => (int)HttpStatusCode.BadRequest,
                    PasswordErrorException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    DuplicateException => (int)HttpStatusCode.Conflict,
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                var result = JsonSerializer.Serialize(new { message = error?.Message, statusCode = response.StatusCode });
                await response.WriteAsync(result);

            }
        }
    }
}
