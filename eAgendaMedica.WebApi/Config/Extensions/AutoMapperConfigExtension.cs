using AutoMapper;
using eAgendaMedica.WebApi.Config.AutoMapperConfig;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class AutoMapperConfigExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile<DoctorProfile>();
                opt.AddProfile<ActivityProfile>();

            });
        }
    }
}
