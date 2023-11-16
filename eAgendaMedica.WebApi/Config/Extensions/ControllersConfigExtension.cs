using eAgenda.WebApi.Filters;
using eAgendaMedica.WebApi.Config.Converters;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class ControllersConfigExtension
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(config => { config.Filters.Add<SerilogActionFilter>(); })
                .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()));
        }
    }
}
