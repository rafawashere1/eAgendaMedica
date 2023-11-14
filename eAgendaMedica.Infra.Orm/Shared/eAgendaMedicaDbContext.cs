using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.ActivityModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.Orm.Shared
{
    public class eAgendaMedicaDbContext : DbContext
    {
        public eAgendaMedicaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorMapperOrm());

            modelBuilder.ApplyConfiguration(new ActivityMapperOrm());

            base.OnModelCreating(modelBuilder);
        }
    }
}
