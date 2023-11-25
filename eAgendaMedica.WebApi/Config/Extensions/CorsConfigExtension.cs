namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class CorsConfigExtension
    {
        public static void ConfigureCors(this IServiceCollection services, string name)
        {
            services.AddCors(config =>
            {
                config.AddPolicy(name, services =>
                {
                    services
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }
    }
}
