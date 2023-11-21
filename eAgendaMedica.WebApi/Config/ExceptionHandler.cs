using System.Text.Json;

namespace eAgendaMedica.WebApi.Config
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _requestDelegate(ctx);
            }
            catch (Exception)
            {
                ctx.Response.StatusCode = 500;
                ctx.Response.ContentType = "application/json";

                var problem = new
                {
                    Success = false,
                    Errors = new List<string>
                        { "An unexpected error occurred in our application. Please try again later or contact support for assistance." }
                };

                ctx.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        }
    }
}
