using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.ActivityModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.Orm.Shared
{
    public class eAgendaMedicaDbContext : DbContext, IPersistenceContext
    {
        public eAgendaMedicaDbContext(DbContextOptions options) : base(options)
        {

        }

        public async Task<bool> SaveAsync()
        {
            await SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorMapperOrm());

            modelBuilder.ApplyConfiguration(new ActivityMapperOrm());

            base.OnModelCreating(modelBuilder);
        }
    }
}
