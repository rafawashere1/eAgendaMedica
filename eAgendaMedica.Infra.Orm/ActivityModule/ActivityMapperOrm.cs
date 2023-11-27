using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.AuthModule;
using eAgendaMedica.Domain.DoctorModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.Orm.ActivityModule
{
    public class ActivityMapperOrm : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("TBActivity");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Type)
            .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.StartDay)
                .IsRequired();

            builder.Property(x => x.EndDay)
                .IsRequired();

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            Guid userId = Guid.Parse("E7944276-5214-46C7-2755-08DBEDE3DB7D");

            var activity1 = new Activity("Consulta Geral", TypeActivity.Appointment, new DateTime(2023, 11, 26), new DateTime(2023, 11, 26), new TimeSpan(10, 0, 0),
                new TimeSpan(10, 30, 0), "primary")
            {
                UserId = userId
            };

            var activity2 = new Activity("Checkup", TypeActivity.Appointment, new DateTime(2023, 11, 26), new DateTime(2023, 11, 26), new TimeSpan(11, 0, 0),
                new TimeSpan(11, 30, 0), "primary")
            {
                UserId = userId
            };

            var activity3 = new Activity("Exame de Sangue", TypeActivity.Appointment, new DateTime(2023, 11, 26), new DateTime(2023, 11, 26), new TimeSpan(12, 0, 0),
                new TimeSpan(12, 30, 0), "primary")
            {
                UserId = userId
            };

            var activity4 = new Activity("Cirurgia Cardíaca", TypeActivity.Surgery, new DateTime(2023, 11, 26), new DateTime(2023, 11, 26), new TimeSpan(11, 0, 0),
                new TimeSpan(11, 30, 0), "accent")
            {
                UserId = userId
            };

            var activity5 = new Activity("Cirurgia de Emergência", TypeActivity.Surgery, new DateTime(2023, 11, 26), new DateTime(2023, 11, 26), new TimeSpan(11, 0, 0),
                new TimeSpan(11, 30, 0), "warn")
            {
                UserId = userId
            };

            builder.HasData(activity1, activity2, activity3, activity4, activity5);

            builder.HasMany(a => a.Doctors)
                   .WithMany(d => d.Activities)
                   .UsingEntity<Dictionary<string, object>>("TBDoctor_TBActivity",
                   x => x.HasOne<Doctor>().WithMany().HasForeignKey("DoctorId"),
                   x => x.HasOne<Activity>().WithMany().HasForeignKey("ActivityId"),
                   x =>
                   {
                   x.HasKey("ActivityId", "DoctorId");
                       x.HasData(
                       new
                       {
                           ActivityId = activity1.Id,
                           DoctorId = Guid.Parse("6f095f41-5503-42a2-8412-8d2bb95c0042")
                       },
                       new
                       {
                           ActivityId = activity2.Id,
                           DoctorId = Guid.Parse("1cc3bb32-627c-4e79-9f4a-3fbff06bbbdf")
                       },
                       new
                       {
                           ActivityId = activity3.Id,
                           DoctorId = Guid.Parse("6275b95e-03e9-4213-9303-f0745608f706")
                       },
                       new
                       {
                           ActivityId = activity4.Id,
                           DoctorId = Guid.Parse("c20e745a-da4c-4f8f-9f8f-7d5c74cafb6f")
                       },
                       new
                       {
                           ActivityId = activity5.Id,
                           DoctorId = Guid.Parse("ad42d17f-9f8d-4f5b-983e-6ad44906b347")
                       }
    );
                   }
            );
        }
    }
}
