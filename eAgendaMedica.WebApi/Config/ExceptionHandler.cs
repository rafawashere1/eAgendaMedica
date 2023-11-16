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
                        { "Nossa aplicação está com alguns problemas, tente novamente mais tarde" }
                };

                ctx.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        }
    }
}
