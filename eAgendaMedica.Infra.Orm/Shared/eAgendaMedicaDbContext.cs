using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.AuthModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.ActivityModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eAgendaMedica.Infra.Orm.Shared
{
    public class eAgendaMedicaDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IPersistenceContext
    {
        private readonly Guid _userId;
        public eAgendaMedicaDbContext(DbContextOptions options, ITenantProvider tenantProvider = null) : base(options)
        {
            if (tenantProvider != null)
                _userId = tenantProvider.UserId;
        }

        public async Task<bool> SaveAsync()
        {
            await SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type type = typeof(eAgendaMedicaDbContext);
            Assembly dllWithConfigurationsOrm = type.Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllWithConfigurationsOrm);

            modelBuilder.Entity<Doctor>().HasQueryFilter(x => x.UserId == _userId);
            modelBuilder.Entity<Activity>().HasQueryFilter(x => x.UserId == _userId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
