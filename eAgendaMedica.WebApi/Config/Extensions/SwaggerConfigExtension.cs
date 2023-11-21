using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class SwaggerConfigExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
            });
        }
    }
}
