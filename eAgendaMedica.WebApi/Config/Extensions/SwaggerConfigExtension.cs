namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class SwaggerConfigExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
