using eAgendaMedica.Domain.ActivityModule;
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

            builder.HasMany(a => a.Doctors)
                .WithMany(d => d.Activities)
                .UsingEntity<Dictionary<string, object>>("TBDoctor_TBActivity",
                x => x.HasOne<Doctor>().WithMany().HasForeignKey("DoctorId"),
                x => x.HasOne<Activity>().WithMany().HasForeignKey("ActivityId")
    );

            builder.HasOne(x => x.User)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
