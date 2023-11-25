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
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "eAgendaMedica.Webapi", Version = "v1" });

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor, informe o token neste padrão {Bearer token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

                x.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00")
                });

                x.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString($"{DateTime.UtcNow:yyyy-MM-dd}")
                });
            });
        }
    }
}
