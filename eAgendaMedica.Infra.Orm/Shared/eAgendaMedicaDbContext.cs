using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
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
            modelBuilder.Entity<Doctor>(builder =>
            {
                builder.ToTable("TBDoctor");

                builder.Property(x => x.Id)
                    .ValueGeneratedNever();

                builder.Property(x => x.CRM)
                    .IsRequired();

                builder.Property(x => x.Name)
                    .IsRequired();

                builder.Property(x => x.LastActivity)
                    .IsRequired();

                builder.HasOne(d => d.CurrentActivity)
                    .WithMany()
                    .HasForeignKey(d => d.CurrentActivityId)
                    .HasConstraintName("FK_TBActivity_TBDoctor")
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Activity>(builder =>
            {
                builder.ToTable("TBActivity");

                builder.Property(x => x.Id)
                    .ValueGeneratedNever();

                builder.Property(x => x.Type)
                .HasConversion<int>()
                    .IsRequired();

                builder.Property(x => x.StartTime)
                    .IsRequired();

                builder.Property(x => x.EndTime)
                    .IsRequired();

                builder.HasMany(a => a.Doctors)
                    .WithMany();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
