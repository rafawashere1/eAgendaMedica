using eAgendaMedica.Application.ActivityModule;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.ActivityModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using eAgendaMedica.WebApi.Config.AutoMapperConfig.MappingActions;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class DependencyInjectionConfigExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSql");

            services.AddDbContext<IPersistenceContext, eAgendaMedicaDbContext>(optionsBulder =>
            {
                optionsBulder.UseNpgsql(connectionString);
            });

            services.AddTransient<ITenantProvider, TenantProvider>();

            services.AddTransient<IDoctorRepository, DoctorRepositoryOrm>();
            services.AddTransient<DoctorAppService>();

            services.AddTransient<IActivityRepository, ActivityRepositoryOrm>();
            services.AddTransient<ActivityAppService>();

            services.AddTransient<ConfigureActivityMappingAction>();
        }
    }
}
