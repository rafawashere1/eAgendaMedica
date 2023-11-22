using eAgendaMedica.Domain.ActivityModule;
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
               .WithOne(d => d.CurrentActivity)
               .HasForeignKey(d => d.CurrentActivityId)
               .HasConstraintName("FK_TBDoctor_TBActivity")
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
