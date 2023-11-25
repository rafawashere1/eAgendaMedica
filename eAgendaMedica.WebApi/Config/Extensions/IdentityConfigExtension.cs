using eAgendaMedica.Application.AuthModule;
using eAgendaMedica.Domain.AuthModule;
using eAgendaMedica.Infra.Orm.Shared;
using eAgendaMedica.WebApi.IdentityConfig;
using Microsoft.AspNetCore.Identity;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class IdentityConfigExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddTransient<AuthAppService>();

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<eAgendaMedicaDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<eAgendaMedicaIdentityErrorDescriber>();
        }
    }
}
