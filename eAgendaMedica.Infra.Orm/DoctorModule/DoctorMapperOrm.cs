using eAgendaMedica.Domain.DoctorModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgendaMedica.Infra.Orm.DoctorModule
{
    public class DoctorMapperOrm : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
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
        }
    }
}
